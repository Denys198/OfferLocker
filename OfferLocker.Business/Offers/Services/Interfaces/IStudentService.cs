using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Models.Student;
using OfferLocker.Entities.Identity;

using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentModel> Add(UpsertStudentModel model);
        Task<PaginatedList<StudentModel>> Get(SearchModel model);
        Task<StudentModel> GetById(Guid id);
        Task Update(Guid id, UpsertStudentModel model);
        Task Delete(Guid id);
    }
}
