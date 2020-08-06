using OfferLocker.Business.Offers.Models.CampusCommunity;
using OfferLocker.Business.Offers.Models.Offer;
using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface ICampusCommunityService
    {
        Task<CampusCommunityModel> Add(UpsertCampusCommunityModel model);
        Task<PaginatedList<CampusCommunityModel>> Get(SearchModel model);
        Task<CampusCommunityModel> GetById(Guid id);
        Task Update(Guid id, UpsertCampusCommunityModel model);
        Task Delete(Guid id);
    }
}
