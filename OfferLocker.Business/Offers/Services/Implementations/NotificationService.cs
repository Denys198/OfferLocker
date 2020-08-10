using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using OfferLocker.Business.Offers.Models.Notification;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons.Interfaces;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class NotificationService : INotificationService
    {
        private readonly INotificationRepository repository;
        private readonly IMapper mapper;

        public NotificationService(INotificationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IList<NotificationModel> GetAllByUserId(Guid id)
        {
            var listNotif = repository.GetAllById(id);
            var list = new List<NotificationModel>();
            foreach(var n in listNotif)
            {
                list.Add(mapper.Map<NotificationModel>(n));
            }
            return list;
        }
        public async Task Delete(Guid id)
        {
            var notification = await repository.GetById(id);

            repository.Delete(notification);
            await repository.SaveChanges();
        }
    }
}
