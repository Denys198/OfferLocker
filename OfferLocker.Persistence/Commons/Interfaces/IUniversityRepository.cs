using System.Collections.Generic;
using LinqBuilder.Core;
using System.Threading.Tasks;

using OfferLocker.Entities.Commons;

namespace OfferLocker.Persistence.Commons.Interfaces
{
    public interface IUniversityRepository : IRepository<University>
    {
        Task<IList<University>> Get(ISpecification<University> spec);
        Task<int> CountAsync();
    }
}
