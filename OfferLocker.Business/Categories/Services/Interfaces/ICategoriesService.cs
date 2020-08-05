using OfferLocker.Business.Categories.Models;
using OfferLocker.Business.Offers.Models.Offer;
using System;
using System.Threading.Tasks;

namespace OfferLocker.Business.Categories.Services.Interfaces
{
	public interface ICategoriesService
	{
		Task<CategoryModel> Add(UpsertCategoryModel model);

		Task<PaginatedList<CategoryModel>> Get(SearchModel model);

		Task<CategoryModel> GetById(Guid id);

		Task Update(Guid id, UpsertCategoryModel model);

		Task Delete(Guid id);
	}
}
