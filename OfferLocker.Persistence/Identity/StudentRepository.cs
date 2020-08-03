using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

using OfferLocker.Entities.Identity;

namespace OfferLocker.Persistence.Identity
{
    public sealed class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(OffersContext context) : base(context) { }

        public async Task<IList<Student>> Get(ISpecification<Student> spec)
            => await this.context.Students.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Students.CountAsync();
    }
}
