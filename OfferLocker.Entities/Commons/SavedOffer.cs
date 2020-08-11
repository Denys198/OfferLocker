using System;
using System.Diagnostics.CodeAnalysis;

namespace OfferLocker.Entities.Commons
{
    public class SavedOffer : Entity
    {
        public SavedOffer(Guid offerId, Guid userId)
        {
            this.OfferId = offerId;
            this.UserId = userId;
        }
        [AllowNull]
        public Guid OfferId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
