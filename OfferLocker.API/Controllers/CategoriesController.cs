using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Categories.Models;
using OfferLocker.Business.Categories.Services.Interfaces;
using OfferLocker.Business.Offers.Models.Offer;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
	[ApiController]
	[Route("api/v1/categories")]
	[Authorize]
	public sealed class CategoriesController : ControllerBase
	{
		private readonly ICategoriesService _categoriesService;

		public CategoriesController(ICategoriesService categoriesService)
		{
			_categoriesService = categoriesService;
		}

		[HttpGet]
		public async Task<IActionResult> Search([FromQuery] SearchModel model)
		{
			var result = await _categoriesService.Get(model);

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			var result = await _categoriesService.GetById(id);

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] UpsertCategoryModel model)
		{
			var result = await _categoriesService.Add(model);
			return Created(result.Id.ToString(), null);
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertCategoryModel model)
		{
			await _categoriesService.Update(id, model);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _categoriesService.Delete(id);

			return NoContent();
		}
	}
}
