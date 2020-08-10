using OfferLocker.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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
