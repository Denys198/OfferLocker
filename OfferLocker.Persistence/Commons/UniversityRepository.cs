using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons
{
    public sealed class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(OffersContext context) : base(context) { }

        public async Task<IList<University>> Get(ISpecification<University> spec)
            => await this.context.Universities.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Universities.CountAsync();
    }
}
