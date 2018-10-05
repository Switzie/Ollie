using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ollie.Exceptions;
using Ollie.Managers;
using Ollie.Models;

namespace Ollie.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager _userManager;
        private readonly PetManager _petManager;

        public UsersController(UserManager userManager, PetManager petManager)
        {
            _userManager = userManager;
            _petManager = petManager;
        }

        public IActionResult Index()
        {
            try
            {
                return View(_userManager.GetUsers());
            }
            catch (Exception ex)
            {
                if (ex is DataAccessException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while attempting to retreieve this resource.");
                }
                return StatusCode(StatusCodes.Status500InternalServerError,"An unexpected error occurred while processing this request");
            }
            
        }

        [HttpGet("Users/{id}/Pets")]
        public IActionResult Pets(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var pet = _petManager.GetPetByOwnerId(id);
                if (pet == null)
                {
                    return NotFound();
                }

                return View(pet);
            }
            catch (Exception ex)
            {
                if (ex is DataAccessException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while attempting to retreieve this resource.");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while processing this request");
            }
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OnboardFormViewModel form)
        {
            try
            {
                if (!ModelState.IsValid) return View(form);
                await _userManager.CreateOwner(form);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (ex is DataAccessException)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while attempting to retreieve this resource.");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred while processing this request");
            }
        }
    }
}
