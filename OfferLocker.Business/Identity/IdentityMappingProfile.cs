using AutoMapper;
using OfferLocker.Business.Identity.Models;
using OfferLocker.Entities.Identity;

namespace OfferLocker.Business.Identity
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
