using OfferLocker.Business.Offers.Models.Faculty;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Entities.Commons;
using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyModel> Add(UpsertFacultyModel model);
        Task<PaginatedList<FacultyModel>> Get(SearchModel model);
        Task<FacultyModel> GetById(Guid id);
        Task Update(Guid id, UpsertFacultyModel model);
        Task Delete(Guid id);
    }
}
