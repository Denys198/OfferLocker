using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;

using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        Task<IList<Faculty>> Get(ISpecification<Faculty> spec);
        Task<int> CountAsync();
    }
}
