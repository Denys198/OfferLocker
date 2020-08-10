using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Entities.Commons
{
    public class NotificationsToUsers : Entity
    {
        public NotificationsToUsers(Guid notificationId, Guid userId) : base()
        {
            NotificationId = notificationId;
            UserId = userId;
        }
        public Guid NotificationId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
