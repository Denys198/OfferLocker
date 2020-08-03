using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Identity.Models;
using OfferLocker.Business.Identity.Services.Interfaces;
using System.Threading.Tasks;

namespace OfferLocker.API.NewFolder
{
    [Route("api/v1/auth")]
    [ApiController]
    public sealed class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest model)
        {
            var result = await _authenticationService.Authenticate(model);
            if (result == null)
            {
                return BadRequest("Incorrect username or password");
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var result = await _authenticationService.Register(model);
            if (result == null)
            {
                return BadRequest();
            }

            return Created(result.Id.ToString(), null);
        }
    }
}
