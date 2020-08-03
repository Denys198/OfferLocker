using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/CampusCommunities")]
    [ApiController]
    public class CampusCommunityController : ControllerBase
    {
        private readonly ICampusCommunityService campusCommunityService;

        public CampusCommunityController(ICampusCommunityService campusCommunityService)
        {
            this.campusCommunityService = campusCommunityService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await campusCommunityService.GetById(id);
            return Ok(result);
        }
    }
}
