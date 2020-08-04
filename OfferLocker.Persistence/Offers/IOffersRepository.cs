using LinqBuilder.Core;
using OfferLocker.Entities.Commons;
using OfferLocker.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Offers
{
	public interface IOffersRepository : IRepository<Offer>
	{
		Task<IList<Offer>> Get(ISpecification<Offer> spec);

		Task<int> CountAsync();

		Task<Offer> GetByIdWithPhotos(Guid id);

		Task<Offer> GetByIdWithComments(Guid id);
	}
}
