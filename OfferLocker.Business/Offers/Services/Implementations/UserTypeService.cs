using OfferLocker.Persistence.Commons;
using AutoMapper;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Models.UserType;
using OfferLocker.Entities.Identity;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Extensions;
using System.Collections.Generic;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository repository;
        private readonly IMapper mapper;

        public UserTypeService(IUserTypeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UserTypeModel> Add(UpsertUserTypeModel model)
        {
            var userType = new UserType(model.Name, model.Description);

            await repository.Add(userType);
            await repository.SaveChanges();

            return mapper.Map<UserTypeModel>(userType);
        }
        public async Task<PaginatedList<UserTypeModel>> Get(SearchModel model)
        {
            var spec = model.ToSpecification<UserType>();

            var entities = await repository.Get(spec);
            var count = await repository.CountAsync();

            return new PaginatedList<UserTypeModel>(
                model.PageIndex,
                entities.Count,
                count,
                mapper.Map<IList<UserTypeModel>>(entities));
        }
        public async Task<UserTypeModel> GetById(Guid id)
        {
            var userType = await repository.GetById(id);

            return mapper.Map<UserTypeModel>(userType);
        }
        public async Task Update(Guid id, UpsertUserTypeModel model)
        {
            var userType = await repository.GetById(id);

            userType.Update(model.Name, model.Description);

            repository.Update(userType);

            await repository.SaveChanges();
        }
        public async Task Delete(Guid id)
        {
            var userType = await repository.GetById(id);

            repository.Delete(userType);
            await repository.SaveChanges();
        }
    }
}
