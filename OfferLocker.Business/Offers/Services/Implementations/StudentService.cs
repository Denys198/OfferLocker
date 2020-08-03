using OfferLocker.Business.Offers.Models.Student;
using OfferLocker.Entities.Identity;
using OfferLocker.Persistence.Identity;

using AutoMapper;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Services.Interfaces;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class StudentService : IStudentService
    {
        private readonly IStudentRepository repository;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<StudentModel> GetById(Guid id)
        {
            var faculty = await repository.GetById(id);

            return mapper.Map<StudentModel>(faculty);
        }
        public async Task<StudentModel> Create(CreateStudentModel model)
        {
            var student = new Student(model.Name, model.Age, model.Year, model.Specialization, model.PhoneNumber, model.Email);

            await repository.Add(student);
            await repository.SaveChanges();

            return mapper.Map<StudentModel>(student);
        }
    }
}
