using OfferLocker.Business.Offers.Models.Student;
using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentModel> GetById(Guid id);
        Task<StudentModel> Create(CreateStudentModel model);
    }
}
