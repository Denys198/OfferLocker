using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Identity.Services.Implementations;
using OfferLocker.Business.Identity.Services.Interfaces;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail([FromRoute]string email)
        {
            var result = await userService.GetByEmail(email);

            return Ok(result);
        }
    }
}
