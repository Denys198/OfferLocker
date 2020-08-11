using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Models.Faculty;
using OfferLocker.Business.Offers.Models.Offer;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/Faculties")]
    [ApiController]
    //[Authorize]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            this.facultyService = facultyService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            var result = await facultyService.Get(model);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await facultyService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpsertFacultyModel model)
        {
            var result = await facultyService.Add(model);

            return Created(result.Id.ToString(), null);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertFacultyModel model)
        {
            await facultyService.Update(id, model);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await facultyService.Delete(id);

            return NoContent();
        }
    }
}
