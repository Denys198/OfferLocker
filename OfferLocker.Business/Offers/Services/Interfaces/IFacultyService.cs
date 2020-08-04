using OfferLocker.Business.Offers.Models.Faculty;
using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<FacultyModel> GetById(Guid id);
        Task<FacultyModel> Create(CreateFacultyModel model);
    }
}
