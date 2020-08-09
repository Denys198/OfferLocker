using OfferLocker.Business.Identity.Models;
using System.Runtime.CompilerServices;

namespace OfferLocker.UnitTests.Shared.Extensions
{
    public static class AuthenticationRequestExtensions
    {
        public static AuthenticationRequest WithEmail(this AuthenticationRequest request, string email)
        {
            request.Email = email;
            return request;
        }

        public static AuthenticationRequest WithPassword(this AuthenticationRequest request, string password)
        {
            request.Password = password;
            return request;
        }
    }
}
