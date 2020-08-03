using OfferLocker.Persistence.Commons;
using OfferLocker.Business.Offers.Models.University;
using OfferLocker.Entities.Commons;

using AutoMapper;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Services.Interfaces;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository repository;
        private readonly IMapper mapper;

        public UniversityService(IUniversityRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UniversityModel> GetById(Guid id)
        {
            var university = await repository.GetById(id);

            return mapper.Map<UniversityModel>(university);
        }
        public async Task<UniversityModel> Create(CreateUniversityModel model)
        {
            var university = new University(model.Name, model.City);

            await repository.Add(university);
            await repository.SaveChanges();

            return mapper.Map<UniversityModel>(university);
        }
    }
}
