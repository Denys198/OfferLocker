using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;

using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons
{
    public interface ICampusCommunityRepository : IRepository<CampusCommunity>
    {
        Task<IList<CampusCommunity>> Get(ISpecification<CampusCommunity> spec);
        Task<int> CountAsync();
    }
}
