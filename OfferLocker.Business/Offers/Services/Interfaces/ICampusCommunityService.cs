using OfferLocker.Business.Offers.Models.CampusCommunity;
using OfferLocker.Entities.Commons;

using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface ICampusCommunityService
    {
        Task<CampusCommunityModel> GetById(Guid id);
        Task<CampusCommunityModel> Create(CreateCampusCommunityModel model);
        Task<CampusCommunityModel> Delete(Guid Id, Guid commentId);
    }
}
