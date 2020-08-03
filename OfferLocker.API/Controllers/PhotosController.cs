using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Offers.Models.Photo;
using OfferLocker.Business.Offers.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
    [ApiController]
    [Route("api/v1/offers/{offerId}/photos")]
    [Authorize]
    public sealed class PhotosController : ControllerBase
    {
        private readonly IPhotosService _photosService;

        public PhotosController(IPhotosService photosService)
        {
            _photosService = photosService;
        }

        [HttpGet("{photoId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid offerId, [FromRoute] Guid photoId)
        {
            var result = await _photosService.GetById(offerId, photoId);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid offerId)
        {
            var result = await _photosService.Get(offerId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid offerId, [FromForm] CreatePhotoModel model)
        {
            var result = await _photosService.Add(offerId, model);

            return Created(result.Id.ToString(), null);
        }
    }
}
