using OfferLocker.Business.Identity.Models;
using OfferLocker.UnitTests.Shared.Extensions;

namespace OfferLocker.UnitTests.Shared.Factories
{
    public class UserRegisterModelFactory
    {
        public static UserRegisterModel Default()
        {
            return new UserRegisterModel()
            {
                Email = "email@gmail.com",
                FullName = "Nume Prenume",
                Password = "parolaBuna"
            };
        }

        public static UserRegisterModel WithEmailNull()
        {
            return Default().WithEmail(null);
        }

        public static UserRegisterModel WithFullNameNull()
        {
            return Default().WithFullName(null);
        }

        public static UserRegisterModel WithPasswordNull()
        {
            return Default().WithPassword(null);
        }

    }
}
