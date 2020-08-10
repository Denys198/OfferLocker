using OfferLocker.Persistence.Commons.Interfaces;
using OfferLocker.Business.Offers.Models.University;
using OfferLocker.Entities.Commons;
using AutoMapper;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;
using LinqBuilder.Core;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Extensions;

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

        public async Task<UniversityModel> Add(UpsertUniversityModel model)
        {
            var university = new University(model.Name, model.City);

            await repository.Add(university);
            await repository.SaveChanges();

            return mapper.Map<UniversityModel>(university);
        }
        public async Task<PaginatedList<UniversityModel>> Get(SearchModel model)
        {
            var spec = model.ToSpecification<University>();

            var entities = await repository.Get(spec);
            var count = await repository.CountAsync();

            return new PaginatedList<UniversityModel>(
                model.PageIndex,
                entities.Count,
                count,
                mapper.Map<IList<UniversityModel>>(entities));
        }
        public async Task<UniversityModel> GetById(Guid id)
        {
            var university = await repository.GetById(id);

            return mapper.Map<UniversityModel>(university);
        }
        public async Task Update(Guid id, UpsertUniversityModel model)
        {
            var university = await repository.GetById(id);

            university.Update(model.Name, model.City);

            repository.Update(university);

            await repository.SaveChanges();
        }
        public async Task Delete(Guid id)
        {
            var univ = await repository.GetById(id);

            repository.Delete(univ);
            await repository.SaveChanges();
        }
    }
}
