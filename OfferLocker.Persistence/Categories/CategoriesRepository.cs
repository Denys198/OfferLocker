using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;
using OfferLocker.Entities.Category;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Categories
{
	public sealed class CategoriesRepository : Repository<Category>, ICategoriesRepository
	{
		public CategoriesRepository(OffersContext context) : base(context) { }

		public async Task<IList<Category>> Get(ISpecification<Category> spec)
			=> await this.context.Categories.ExeSpec(spec).ToListAsync();

		public async Task<int> CountAsync()
			=> await this.context.Categories.CountAsync();

		public async Task<Category> GetByName(string name) =>
			await context.Categories.Where(x => x.Name == name).FirstOrDefaultAsync();
	}
}
