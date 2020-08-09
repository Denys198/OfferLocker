using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OfferLocker.Persistence.Commons.Implementations
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(OffersContext context) : base(context) { }

        public List<Notification> GetAllById(Guid userId)
        {
            var result = from user in context.Users
                         join not2usr in context.NotificationToUsers on user.Id equals not2usr.UserId
                         join notif in context.Notifications on not2usr.NotificationId equals notif.Id
                         where user.Id == userId
                         select notif;
            return result.ToList<Notification>();
        }

    }
}
