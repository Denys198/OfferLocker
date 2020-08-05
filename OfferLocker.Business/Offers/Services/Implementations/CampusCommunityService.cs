using OfferLocker.Business.Offers.Models.CampusCommunity;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons;

using System;
using AutoMapper;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Extensions;
using System.Collections.Generic;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class CampusCommunityService : ICampusCommunityService
    {
        private readonly ICampusCommunityRepository repository;
        private readonly IMapper mapper;

        public CampusCommunityService(ICampusCommunityRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CampusCommunityModel> Add(UpsertCampusCommunityModel model)
        {
            var campusCommunity = new CampusCommunity(model.Name, model.Description, model.Image, model.Link, model.StudentsNumber, model.IdUser);

            await repository.Add(campusCommunity);
            await repository.SaveChanges();

            return mapper.Map<CampusCommunityModel>(campusCommunity);
        }
        public async Task<PaginatedList<CampusCommunityModel>> Get(SearchModel model)
        {
            var spec = model.ToSpecification<CampusCommunity>();

            var entities = await repository.Get(spec);
            var count = await repository.CountAsync();

            return new PaginatedList<CampusCommunityModel>(
                model.PageIndex,
                entities.Count,
                count,
                mapper.Map<IList<CampusCommunityModel>>(entities));
        }
        public async Task<CampusCommunityModel> GetById(Guid id)
        {
            var campusCommunity = await repository.GetById(id);

            return mapper.Map<CampusCommunityModel>(campusCommunity);
        }
        public async Task Update(Guid id, UpsertCampusCommunityModel model)
        {
            var campusCommunity = await repository.GetById(id);

            campusCommunity.Update(model.Name, model.Description, model.Image, model.Link, model.StudentsNumber, model.IdUser);

            repository.Update(campusCommunity);

            await repository.SaveChanges();
        }
        public async Task Delete(Guid id)
        {
            var campComm = await repository.GetById(id);

            repository.Delete(campComm);
            await repository.SaveChanges();
        }
    }
}
