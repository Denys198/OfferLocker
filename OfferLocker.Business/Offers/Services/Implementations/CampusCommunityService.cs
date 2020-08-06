using OfferLocker.Business.Offers.Models.CampusCommunity;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons;

using System;
using AutoMapper;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class CampusCommunityService 
    {
        private readonly ICampusCommunityRepository repository;
        private readonly IMapper mapper;

        public CampusCommunityService(ICampusCommunityRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CampusCommunityModel> GetById(Guid id)
        {
            var campusCommunity = await repository.GetById(id);

            return mapper.Map<CampusCommunityModel>(campusCommunity);
        }
        public async Task<CampusCommunityModel> Create(CreateCampusCommunityModel model)
        {
            var campusCommunity = new CampusCommunity(model.Name, model.Description, model.Image, model.Link, model.StudentsNumber, model.IdUser);

            await repository.Add(campusCommunity);
            await repository.SaveChanges();

            return mapper.Map<CampusCommunityModel>(campusCommunity);
        }
    }
}
