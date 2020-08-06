using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/follow")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;
        private IHttpContextAccessor _httpContextAccessor;
        public FollowController(IFollowService followService,  IHttpContextAccessor httpContextAccessor)
        {
            _followService = followService;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// get logged user's list of users that he follows
        /// </summary>
        /// <returns></returns>
        [HttpGet("following")]
        public async Task<IActionResult> GetFollowingUserList()
        {
            var ext = new OfferLocker.Business.Extensions(_httpContextAccessor);
            var loggedUserId = ext.GetLoggedUserId();

            if (loggedUserId == null)
                return BadRequest("in need of token");

            var result = await _followService.GetFollowingUsersList(Guid.Parse(loggedUserId));
            return Ok(result);
        }

        /// <summary>
        /// get logged user's list of users that follow him
        /// </summary>
        /// <returns></returns>
        [HttpGet("followers")]
        public async Task<IActionResult> GetFollowersUserList()
        {
            var ext = new OfferLocker.Business.Extensions(_httpContextAccessor);
            var id = ext.GetLoggedUserId();

            if (id == null)
                return BadRequest("in need of token");

            var result = await _followService.GetFollowersUsersList(Guid.Parse(id));
            return Ok(result);
        }


        /// <summary>
        /// add users to logged user's list of following
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> FollowUsers([FromBody] IList<Guid> userIds)
        {
            var ext = new OfferLocker.Business.Extensions(_httpContextAccessor);
            var loggedUserId = ext.GetLoggedUserId();

            if (loggedUserId == null)
                return BadRequest("in need of token");

            await _followService.FollowUsers(Guid.Parse(loggedUserId), userIds);
            return Ok();
        }

        /// <summary>
        /// delete users to logged user's list of following
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> UnfollowUsers([FromBody] IList<Guid> userIds)
        {
            var extensie = new Business.Extensions(_httpContextAccessor);
            var loggedUserId = extensie.GetLoggedUserId();

            if (loggedUserId == null)
                return BadRequest("in need of token");

            await _followService.UnfollowUsers(Guid.Parse(loggedUserId), userIds);
            return Ok();
        }
    }
}
