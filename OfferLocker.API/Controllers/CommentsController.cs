using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferLocker.Business.Offers.Models.Comment;
using OfferLocker.Business.Offers.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OfferLocker.API.Controllers
{
    [ApiController]
    [Route("api/v1/offers/{offerId}/comments")]
    [Authorize]
    public sealed class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid offerId)
        {
            var result = await _commentsService.Get(offerId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid offerId, [FromBody] CreateCommentModel model)
        {
            var result = await _commentsService.Add(offerId, model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid offerId, [FromRoute] Guid commentId)
        {
            await _commentsService.Delete(offerId, commentId);

            return NoContent();
        }
    }
}
