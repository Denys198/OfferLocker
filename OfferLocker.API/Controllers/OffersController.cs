using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
    [ApiController]
    [Route("api/v1/offers")]
    [Authorize]
    public sealed class OffersController : ControllerBase
    {
        private readonly IOffersService _offersService;

        public OffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            var result = await _offersService.Get(model);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _offersService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpsertOfferModel model)
        {
            var result = await _offersService.Add(model);
            return Created(result.Id.ToString(), null);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertOfferModel model)
        {
            await _offersService.Update(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _offersService.Delete(id);

            return NoContent();
        }
    }
}
