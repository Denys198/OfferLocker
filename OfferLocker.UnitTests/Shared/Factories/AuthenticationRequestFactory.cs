using OfferLocker.Business.Identity.Models;
using OfferLocker.UnitTests.Shared.Extensions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace OfferLocker.UnitTests.Shared.Factories
{
    public class AuthenticationRequestFactory
    {
        public static AuthenticationRequest Default()
        {
            return new AuthenticationRequest()
            {
                Email = "email@gmail.com",
                Password = "parolaBuna"
            };
        }

        public static AuthenticationRequest WithEmailNull()
        {
            return Default().WithEmail(null);
        }

        public static AuthenticationRequest WithPasswordNull()
        {
            return Default().WithPassword(null);
        }
    }
}
