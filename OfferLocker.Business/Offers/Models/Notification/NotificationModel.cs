using System;

namespace OfferLocker.Business.Offers.Models.Notification
{
    public sealed class NotificationModel
    {
        public Guid Id { get; private set; }
        public string Message { get; private set; }
    }
}
