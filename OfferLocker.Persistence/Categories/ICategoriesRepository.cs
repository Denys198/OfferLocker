using LinqBuilder.Core;
using OfferLocker.Entities.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Categories
{
	public interface ICategoriesRepository : IRepository<Category>
	{
		Task<IList<Category>> Get(ISpecification<Category> spec);

		Task<int> CountAsync();

		Task<Category> GetByName(string name);
	}
}
