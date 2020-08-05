using OfferLocker.Business.Offers.Models.University;
using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IUniversityService
    {
        Task<UniversityModel> GetById(Guid id);
        Task<UniversityModel> Create(CreateUniversityModel model);
    }
}
