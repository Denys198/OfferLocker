using OfferLocker.Entities.Commons;
using OfferLocker.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfferLocker.Persistence
{
    public class SendNotificationModule
    {
        public enum Action { Update, Delete}
        public static void SendNotification(OffersContext context, Offer offer, Action action)
        {
            var offerId = offer.Id;
            var usrIds = context.SavedOffers.Where(p => p.OfferId == offer.Id).ToList<SavedOffer>();

            Notification notification = null;
            if(action == Action.Update)
            {
                notification = new Notification("Oferta avand urmatoarele detalii a fost modificata: Nume: " + offer.Name + ", Descriere: " + offer.Description + ", Pret: "+offer.Price, offer.Id);
            }
            else if (action == Action.Delete)
            {
                notification = new Notification("Oferta avand urmatoarele detalii a fost stearsa: Nume:" + offer.Name + ", Descriere: " + offer.Description + ", Pret: " + offer.Price, null);
            }
            context.Notifications.Add(notification);
            context.SaveChanges();
            foreach (var i in usrIds)
            {
                var usrNot = new NotificationsToUsers(notification.Id, i.UserId);
                context.NotificationToUsers.Add(usrNot);
                context.SaveChanges();
            }
        }
    }
}
