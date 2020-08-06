using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OfferLocker.Business.Offers.Models.UserType;
using Microsoft.AspNetCore.Authorization;
using OfferLocker.Business.Offers.Models.Offer;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/UserTypes")]
    [ApiController]
    [Authorize]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            this.userTypeService = userTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            var result = await userTypeService.Get(model);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await userTypeService.GetById(id);
            return Ok(result);   
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpsertUserTypeModel model)
        {
            var result = await userTypeService.Add(model);

            return Created(result.Id.ToString(), null);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertUserTypeModel model)
        {
            await userTypeService.Update(id, model);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await userTypeService.Delete(id);

            return NoContent();
        }
    }
}
