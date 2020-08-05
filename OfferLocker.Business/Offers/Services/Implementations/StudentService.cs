using OfferLocker.Business.Offers.Models.Student;
using OfferLocker.Entities.Identity;
using OfferLocker.Persistence.Identity;

using AutoMapper;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Extensions;
using System.Collections;
using System.Collections.Generic;

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

        public async Task<StudentModel> Add(UpsertStudentModel model)
        {
            var student = new Student(model.Name, model.Age, model.Year, model.Specialization, model.PhoneNumber, model.Email);

            await repository.Add(student);
            await repository.SaveChanges();

            return mapper.Map<StudentModel>(student);
        }
        public async Task<PaginatedList<StudentModel>> Get(SearchModel model)
        {
            var spec = model.ToSpecification<Student>();

            var entities = await repository.Get(spec);
            var count = await repository.CountAsync();

            return new PaginatedList<StudentModel>(
                model.PageIndex,
                entities.Count,
                count,
                mapper.Map<IList<StudentModel>>(entities));
        }
        public async Task<StudentModel> GetById(Guid id)
        {
            var faculty = await repository.GetById(id);

            return mapper.Map<StudentModel>(faculty);
        }
        public async Task Update(Guid id, UpsertStudentModel model)
        {
            var student = await repository.GetById(id);

            student.Update(model.Name, model.Age, model.Year, model.Specialization, model.PhoneNumber, model.Email);

            repository.Update(student);

            await repository.SaveChanges();
        }
        public async Task Delete(Guid id)
        {
            var student = await repository.GetById(id);

            repository.Delete(student);
            await repository.SaveChanges();
        }
    }
}
