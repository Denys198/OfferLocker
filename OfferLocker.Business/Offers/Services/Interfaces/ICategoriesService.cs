using OfferLocker.Business.Offers.Models.Category;
using OfferLocker.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
	public interface ICategoriesService
	{
		Task<IEnumerable<CategoryModel>> Get(Guid offerId);

		Task<CategoryModel> Add(Guid offerId, CreateCategoryModel model);

		Task Delete(Guid offerId, Guid categoryId);
	}
}
