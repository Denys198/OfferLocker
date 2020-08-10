using LinqBuilder.Core;
using OfferLocker.Entities.Meetup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Identity
{
	public interface IMeetupsRepository : IRepository<Meetup>
	{
		Task<IList<Meetup>> Get(ISpecification<Meetup> spec);

		Task<int> CountAsync();

		Task<Meetup> GetByName(string name);

		Task<IList<Meetup>> GetByUser(Guid userId);
	}
}
