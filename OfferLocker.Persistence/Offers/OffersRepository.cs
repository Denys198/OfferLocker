using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;
using OfferLocker.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Offers
{
	public sealed class OffersRepository : Repository<Offer>, IOffersRepository
	{
        public OffersRepository(OffersContext context) : base(context) { }

        public async Task<IList<Offer>> Get(ISpecification<Offer> spec)
            => await this.context.Offers.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Offers.CountAsync();

        public async Task<Offer> GetByIdWithPhotos(Guid id)
            => await this.context.Offers
                .Include(offer => offer.Comments)
                .Include(offer => offer.Photos)
                .FirstAsync(offer => offer.Id == id);

        public async Task<Offer> GetByIdWithComments(Guid id)
            => await this.context.Offers
                .Include(offer => offer.Comments)
                .FirstAsync(offer => offer.Id == id);

        public async Task<Offer> GetByIdWithCategories(Guid id)
            => await this.context.Offers
                .Include(offer => offer.Categories)
                .FirstAsync(offer => offer.Id == id);

        public async Task<Offer> GetByCategory(Category category) =>
            await context.Offers.Where(x => x.Categories.Contains(category)).FirstOrDefaultAsync();
    }
}
