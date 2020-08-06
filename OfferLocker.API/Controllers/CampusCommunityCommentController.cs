using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OfferLocker.API.Controllers
{
    [ApiController]
    [Route("api/v1/offers/{Id}/comments")]
    [Authorize]
    public sealed class CampusCommunityCommentController : ControllerBase
    {
        private readonly ICampusCommunityCommentService _commentsService;

        public CampusCommunityCommentController(ICampusCommunityCommentService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _commentsService.GetById(id);
            return Ok(result);
        }
        
    }
}
