using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/UserTypes")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            this.userTypeService = userTypeService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await userTypeService.GetById(id);
            return Ok(result);   
        }
    }
}
