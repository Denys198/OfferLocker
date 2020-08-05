using System.Collections.Generic;
using LinqBuilder.Core;
using System.Threading.Tasks;

using OfferLocker.Entities.Commons;
using System.Linq;

namespace OfferLocker.Persistence.Commons
{
    public interface IUniversityRepository : IRepository<University>
    {
        Task<IList<University>> Get(ISpecification<University> spec);
        Task<int> CountAsync();
        Task<List<University>> GetUniversities();
    }
}
