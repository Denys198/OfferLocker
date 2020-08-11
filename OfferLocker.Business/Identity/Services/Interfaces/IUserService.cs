using OfferLocker.Business.Identity.Models;
using System.Threading.Tasks;

namespace OfferLocker.Business.Identity.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetByEmail(string email);
    }
}
