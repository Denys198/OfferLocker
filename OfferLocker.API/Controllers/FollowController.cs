using OfferLocker.Business.Offers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OfferLocker.Persistence;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons;

namespace OfferLocker.API.Controllers
{
    [Route("api/v1/follow")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowRepository _followRepository;

        public FollowController(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAllEntities()
        {
            var result = await _followRepository.GetAll();
            return Ok(result);
        }
    }
}
