using Ollie.Data;

namespace Ollie.Managers
{
    public class UserManager
    {
        private readonly ApplicationDbContext _context;

        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}