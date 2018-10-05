using System;
using Microsoft.EntityFrameworkCore;
using Ollie.Data;
using Ollie.Exceptions;
using Ollie.Models;

namespace Ollie.Managers
{
    public class PetManager
    {
        private readonly ApplicationDbContext _context;

        public PetManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public Pet GetPetByOwnerId(Guid? id)
        {
            try
            {
                return id.HasValue ? _context.Pet.SingleOrDefaultAsync(x => x.OwnerId == id).Result : null;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occured while fetching the pet information", ex);
            }
            
        }
    }
}
