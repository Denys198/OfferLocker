using OfferLocker.Business.Offers.Models.Faculty;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons;

using AutoMapper;
using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository repository;
        private readonly IMapper mapper;

        public FacultyService(IFacultyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<FacultyModel> GetById(Guid id)
        {
            var faculty = await repository.GetById(id);

            return mapper.Map<FacultyModel>(faculty);
        }
        public async Task<FacultyModel> Create(CreateFacultyModel model)
        {
            var faculty = new Faculty(model.Name);

            await repository.Add(faculty);
            await repository.SaveChanges();

            return mapper.Map<FacultyModel>(faculty);
        }
    }
}
