using OfferLocker.Business.Identity.Models;


namespace OfferLocker.UnitTests.Shared.Extensions
{
    public static class UserRegisterModelExtensions
    {

    public static UserRegisterModel WithEmail(this UserRegisterModel model, string email)
        {
            model.Email = email;
            return model;
        }

     public static UserRegisterModel WithFullName(this UserRegisterModel model, string name)
        {
            model.FullName = name;
            return model;
        }


     public static UserRegisterModel WithPassword(this UserRegisterModel model, string password)
        {
            model.Password = password;
            return model;
        }
    }
}
