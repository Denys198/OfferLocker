using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Models.UserType;
using OfferLocker.Entities.Identity;

using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IUserTypeService
    {
        Task<UserTypeModel> Add(UpsertUserTypeModel model);
        Task<PaginatedList<UserTypeModel>> Get(SearchModel model);
        Task<UserTypeModel> GetById(Guid id);
        Task Update(Guid id, UpsertUserTypeModel model);
        Task Delete(Guid id);
    }
}
