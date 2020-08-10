using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;
using OfferLocker.Entities.Meetup;
using OfferLocker.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Meetups
{
	public sealed class MeetupsRepository : Repository<Meetup>, IMeetupsRepository
	{
        public MeetupsRepository(OffersContext context) : base(context) { }

        public async Task<IList<Meetup>> Get(ISpecification<Meetup> spec)
            => await this.context.Meetups.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Meetups.CountAsync();

        public async Task<Meetup> GetByName(string name) =>
            await context.Meetups.Where(x => x.Name == name).FirstOrDefaultAsync();

        public async Task<IList<Meetup>> GetByUser(Guid userId)
            => await context.Meetups.Where(x => x.UserId == userId).ToListAsync();
    }
}
