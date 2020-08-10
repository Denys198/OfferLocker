using OfferLocker.Business.Offers.Models.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface INotificationService
    {
        IList<NotificationModel> GetAllByUserId(Guid id);
        Task Delete(Guid id);
    }
}
