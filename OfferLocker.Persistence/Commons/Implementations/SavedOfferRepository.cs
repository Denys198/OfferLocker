using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons.Interfaces;

namespace OfferLocker.Persistence.Commons.Implementations
{
    public class SavedOfferRepository : Repository<SavedOffer>, ISavedOfferRepository
    {
        public SavedOfferRepository(OffersContext context) : base(context) { }
    }
}
