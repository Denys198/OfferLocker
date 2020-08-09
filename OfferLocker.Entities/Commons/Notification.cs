using OfferLocker.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OfferLocker.Entities.Commons
{
    public class Notification : Entity
    {
        public Notification(string message, Guid? offerId) : base()
        {
            this.Message = message;
            OfferId = offerId;
        }
        public string Message { get; set; }
        [AllowNull]
        public Guid? OfferId { get; set; }
        public ICollection<NotificationsToUsers> ToUsers { get; private set; }
    }
}
