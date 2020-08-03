using OfferLocker.Business.Offers.Models.UserType;
using OfferLocker.Entities.Identity;

using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IUserTypeService
    {
        Task<UserTypeModel> GetById(Guid id);
        Task<UserTypeModel> Create(CreateUserTypeModel model);
    }
}
