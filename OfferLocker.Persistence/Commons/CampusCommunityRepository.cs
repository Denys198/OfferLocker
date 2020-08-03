using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons
{
    public sealed class CampusCommunityRepository : Repository<CampusCommunity>, ICampusCommunityRepository
    {
        public CampusCommunityRepository(OffersContext context) : base(context) { }

        public async Task<IList<CampusCommunity>> Get(ISpecification<CampusCommunity> spec)
            => await this.context.CampusCommunities.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Offers.CountAsync();
    }
}
