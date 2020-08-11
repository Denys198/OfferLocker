using System;

namespace OfferLocker.Business.Offers.Models.Notification
{
    class NotificationToUserModel
    {
        public Guid Id { get; private set; }
        public Guid IdNotification { get; private set; }
        public Guid IdUser { get; private set; }
    }
}
