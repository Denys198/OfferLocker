using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Models.CampusCommunity;
using Microsoft.AspNetCore.Authorization;
using OfferLocker.Business.Offers.Models.Offer;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/CampusCommunities")]
    [ApiController]
    [Authorize]
    public class CampusCommunityController : ControllerBase
    {
        private readonly ICampusCommunityService campusCommunityService;

        public CampusCommunityController(ICampusCommunityService campusCommunityService)
        {
            this.campusCommunityService = campusCommunityService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            var result = await campusCommunityService.Get(model);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await campusCommunityService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpsertCampusCommunityModel model)
        {
            var result = await campusCommunityService.Add(model);

            return Created(result.Id.ToString(), null);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertCampusCommunityModel model)
        {
            await campusCommunityService.Update(id, model);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await campusCommunityService.Delete(id);

            return NoContent();
        }
    }
}
