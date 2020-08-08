using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

using OfferLocker.Persistence.Commons.Interfaces;
using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons.Implementations
{
    public sealed class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(OffersContext context) : base(context) { }

        public async Task<IList<Faculty>> Get(ISpecification<Faculty> spec)
            => await this.context.Faculties.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Faculties.CountAsync();
    }
}
