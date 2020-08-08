using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

using OfferLocker.Persistence.Commons.Interfaces;
using OfferLocker.Entities.Identity;

namespace OfferLocker.Persistence.Commons.Implementations
{
    public sealed class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(OffersContext context) : base(context) { }

        public async Task<IList<UserType>> Get(ISpecification<UserType> spec)
            => await this.context.UserTypes.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.UserTypes.CountAsync();
    }
}
