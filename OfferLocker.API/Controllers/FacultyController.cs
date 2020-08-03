using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/faculties")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            this.facultyService = facultyService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await facultyService.GetById(id);
            return Ok(result);
        }
    }
}
