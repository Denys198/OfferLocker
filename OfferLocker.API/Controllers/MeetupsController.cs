using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Meetups.Models;
using OfferLocker.Business.Meetups.Services.Interfaces;
using OfferLocker.Business.Offers.Models.Offer;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
	[ApiController]
	[Route("api/v1/meetups")]
	[Authorize]
	public sealed class MeetupsController : ControllerBase
	{
		private readonly IMeetupsService _meetupsService;

		public MeetupsController(IMeetupsService meetupsService)
		{
			_meetupsService = meetupsService;
		}

		[HttpGet]
		public async Task<IActionResult> Search([FromQuery] SearchModel model)
		{
			var result = await _meetupsService.Get(model);

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			var result = await _meetupsService.GetById(id);

			return Ok(result);
		}

		[HttpGet("/user-meetups/{userId}")]
		public async Task<IActionResult> SearchByUser([FromRoute] Guid userId)
		{
			var result = await _meetupsService.GetByUser(userId);

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] UpsertMeetupModel model)
		{
			var result = await _meetupsService.Add(model);
			return Created(result.Id.ToString(), null);
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertMeetupModel model)
		{
			await _meetupsService.Update(id, model);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _meetupsService.Delete(id);

			return NoContent();
		}
	}
}
