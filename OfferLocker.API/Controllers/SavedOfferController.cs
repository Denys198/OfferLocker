using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Offers.Models.SavedOffer;
using OfferLocker.Business.Offers.Services.Interfaces;

namespace OfferLocker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedOfferController : ControllerBase
    {
        private readonly ISavedOfferService savedOfferService;
        public SavedOfferController(ISavedOfferService savedOfferService)
        {
            this.savedOfferService = savedOfferService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSavedOfferModel model)
        {
            var result = await savedOfferService.Add(model);

            return Created(result.Id.ToString(), null);
        }
    }
}
