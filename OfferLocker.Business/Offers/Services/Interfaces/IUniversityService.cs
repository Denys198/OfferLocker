using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Models.University;
using OfferLocker.Entities.Commons;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IUniversityService
    {
        Task<UniversityModel> Add(UpsertUniversityModel model);
        Task<PaginatedList<UniversityModel>> Get(SearchModel model);
        Task<UniversityModel> GetById(Guid id);
        Task Update(Guid id, UpsertUniversityModel model);
        Task Delete(Guid id);
    }
}
