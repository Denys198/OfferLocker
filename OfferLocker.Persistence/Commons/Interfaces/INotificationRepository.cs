using OfferLocker.Entities.Commons;
using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence.Commons.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        List<Notification> GetAllById(Guid userId);
    }
}
