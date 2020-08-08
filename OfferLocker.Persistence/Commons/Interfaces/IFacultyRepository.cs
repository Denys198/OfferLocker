using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;

using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons.Interfaces
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        Task<IList<Faculty>> Get(ISpecification<Faculty> spec);
        Task<int> CountAsync();
    }
}
