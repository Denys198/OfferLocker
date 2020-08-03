using Microsoft.EntityFrameworkCore;
using OfferLocker.Entities.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Identity
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        private readonly OffersContext _context;

        public UserRepository(OffersContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email) =>
            await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
    }
}
