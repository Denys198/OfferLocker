using OfferLocker.Business.Offers.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/universities")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService universityService;

        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await universityService.GetById(id);

            return Ok(result);
        }
    }
}
