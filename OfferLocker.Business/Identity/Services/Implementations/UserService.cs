using AutoMapper;
using OfferLocker.Business.Identity.Models;
using OfferLocker.Business.Identity.Services.Interfaces;
using OfferLocker.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Identity.Services.Implementations
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UserModel> GetByEmail(string email)
        {
            var user = await repository.GetByEmail(email);

            return mapper.Map<UserModel>(user);
        }
    }
}