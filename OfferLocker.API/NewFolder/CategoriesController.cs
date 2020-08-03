using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Offers.Models.Category;
using OfferLocker.Business.Offers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferLocker.API.NewFolder
{
	[ApiController]
	[Route("api/v1/offers/{offerId}/categories")]
	[Authorize]
	public sealed class CategoriesController : ControllerBase
	{
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid offerId)
        {
            var result = await _categoriesService.Get(offerId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid offerId, [FromBody] CreateCategoryModel model)
        {
            var result = await _categoriesService.Add(offerId, model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid offerId, [FromRoute] Guid categoryId)
        {
            await _categoriesService.Delete(offerId, categoryId);

            return NoContent();
        }
    }
}
