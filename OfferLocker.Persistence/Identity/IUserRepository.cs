using OfferLocker.Entities.Identity;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Identity
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
