using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using OfferLocker.Entities.Identity;

namespace OfferLocker.Persistence.Identity
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IList<Student>> Get(ISpecification<Student> spec);
        Task<int> CountAsync();
    }
}
