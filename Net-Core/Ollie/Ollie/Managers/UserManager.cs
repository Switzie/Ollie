using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ollie.Data;
using Ollie.Exceptions;
using Ollie.Models;

namespace Ollie.Managers
{
    public class UserManager
    {
        private readonly ApplicationDbContext _context;

        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            try
            {
                return _context.User.ToListAsync().Result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while attempting to retrieve the users list.", ex);
            }
            
        }

        public async Task CreateOwner(OnboardFormViewModel form)
        {
            try
            {
                var owner = new User
                {
                    FirstName = form.User.FirstName,
                    LastName = form.User.LastName,
                    AddressLine1 = form.User.AddressLine1,
                    AddressLine2 = form.User.AddressLine2,
                    City = form.User.City,
                    State = form.User.State,
                    ZipCode = form.User.ZipCode,
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
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while attempting to create the user.", ex);
            }
            
        }
    }
}