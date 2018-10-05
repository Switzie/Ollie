using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollie.Data;
using Ollie.Models;

namespace Ollie.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        [HttpGet("Users/{id}/Pets")]
        public async Task<IActionResult> Pets(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var pet = await _context.Pet.SingleOrDefaultAsync(x => x.OwnerId == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: OnBoard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnBoard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OnboardFormViewModel form)
        {
            if (ModelState.IsValid)
            {

                var owner = new User
                {
                    Name = form.User.Name,
                    AddressLine1 = form.User.AddressLine1,
                    Email = form.User.Email,
                    UserGuid = Guid.NewGuid()
                };
                var pet = new Pet
                {
                    Name = form.Pet.Name,
                    Age = form.Pet.Age,
                    Breed = form.Pet.Breed,
                    OwnerId = owner.UserGuid
                };
                _context.User.Add(owner);
                _context.Pet.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }
    }
}
