using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Persistence.Commons.Implementations
{
    public class SavedOfferRepository : Repository<SavedOffer>, ISavedOfferRepository
    {
        public SavedOfferRepository(OffersContext context) : base(context) { }
    }
}
