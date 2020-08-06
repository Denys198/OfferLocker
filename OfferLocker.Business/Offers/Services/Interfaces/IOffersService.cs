using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
	public interface IOffersService
	{
		Task<OfferModel> Add(UpsertOfferModel model);

		Task<PaginatedList<OfferModel>> Get(SearchModel model);

		Task<OfferModel> GetById(Guid id);

		Task<IList<OfferModel>> GetByCategory(Guid categoryId);

		Task Update(Guid id, UpsertOfferModel model);

		Task Delete(Guid id);
	}
}
