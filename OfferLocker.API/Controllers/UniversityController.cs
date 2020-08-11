using OfferLocker.Business.Offers.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Offers.Models.University;
using OfferLocker.Business.Offers.Models.Offer;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/Universities")]
    [ApiController]
    //[Authorize]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService universityService;

        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            var result = await universityService.Get(model);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await universityService.GetById(id);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpsertUniversityModel model)
        {
            var result = await universityService.Add(model);

            return Created(result.Id.ToString(), null);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertUniversityModel model)
        {
            await universityService.Update(id, model);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await universityService.Delete(id);

            return NoContent();
        }
    }
}
