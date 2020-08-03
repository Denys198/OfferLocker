using OfferLocker.Persistence.Commons;
using AutoMapper;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Models.UserType;
using OfferLocker.Entities.Identity;
using OfferLocker.Business.Offers.Services.Interfaces;

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
        public async Task<UserTypeModel> GetById(Guid id)
        {
            var userType = await repository.GetById(id);

            return mapper.Map<UserTypeModel>(userType);
        }
        public async Task<UserTypeModel> Create(CreateUserTypeModel model)
        {
            var userType = new UserType(model.Name, model.Description);

            await repository.Add(userType);
            await repository.SaveChanges();

            return mapper.Map<UserTypeModel>(userType);
        }
    }
}
