using System;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Offers.Services.Interfaces;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/notifications/")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationByUserId([FromRoute] Guid id)
        {
            var result = notificationService.GetAllByUserId(id);

            return Ok(result);
        }
    }
}
