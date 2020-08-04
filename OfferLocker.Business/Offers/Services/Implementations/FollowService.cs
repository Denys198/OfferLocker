using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Identity;
using OfferLocker.Persistence.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        public FollowService(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }

        public async Task FollowUsers(Guid loggedUserId, IList<Guid> userIds)
        {
            var followingList = await _followRepository.GetFollowingByFollower(loggedUserId);

        }

        public async Task<IList<User>> GetFollowersUsersList(Guid loggedUserId)
        {
            var followedList = await _followRepository.GetFollowersByFollowed(loggedUserId);

            var users = followedList.Select(f => f.Follower).ToList();
            return users;
        }

        public async Task<IList<User>> GetFollowingUsersList(Guid loggedUserId)
        {
            var followingList = await _followRepository.GetFollowingByFollower(loggedUserId);

            var users = followingList.Select(f => f.Followed).ToList();
            return users;
        }
    }
}
