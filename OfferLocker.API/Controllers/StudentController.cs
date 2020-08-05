using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OfferLocker.Business.Offers.Models.Student;
using OfferLocker.Business.Offers.Models.Offer;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/Students")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            var result = await studentService.Get(model);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await studentService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpsertStudentModel model)
        {
            var result = await studentService.Add(model);

            return Created(result.Id.ToString(), null);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertStudentModel model)
        {
            await studentService.Update(id, model);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await studentService.Delete(id);

            return NoContent();
        }
    }
}
