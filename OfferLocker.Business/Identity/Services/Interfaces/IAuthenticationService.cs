using OfferLocker.Business.Identity.Models;
using System.Threading.Tasks;

namespace OfferLocker.Business.Identity.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest userAuthenticationModel);

        Task<UserModel> Register(UserRegisterModel userRegisterModel);
    }
}
