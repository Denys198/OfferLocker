using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;

using OfferLocker.Entities.Identity;

namespace OfferLocker.Persistence.Commons
{
    public interface IUserTypeRepository : IRepository<UserType>
    {
        Task<IList<UserType>> Get(ISpecification<UserType> spec);

        Task<int> CountAsync();
    }
}
