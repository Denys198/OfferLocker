using OfferLocker.Business.Identity.Models;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons.Implementations;
using OfferLocker.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;
        public FollowService(IFollowRepository followRepository, IUserRepository userRepository)
        {
            _followRepository = followRepository;
            _userRepository = userRepository;
        }

        public async Task FollowUsers(Guid loggedUserId, IList<Guid> userIds)
        {
            //1. lista curenta users pe care ii urmarim
            var followingList = await _followRepository.GetFollowingByFollower(loggedUserId);
            var followingIdsList = followingList.Select(f => f.IdUserFollowed).ToList();

            //2.  user id exists
            var existingUsers = await _userRepository.GetAll();
            var existingUsersIds = existingUsers.Select(u => u.Id).ToList();

            //3. comparam id => ids unice
            var uniquesUsersIds = userIds
                .Where(i => !followingIdsList.Contains(i) && existingUsersIds.Contains(i))
                .ToList()
                .Distinct();

            //4. add to db
            foreach (var id in uniquesUsersIds)
            {
                var newFollowEntity = new Follow(loggedUserId, id);
                await _followRepository.Add(newFollowEntity);
                await _followRepository.SaveChanges();
            }

            //await _followRepository.AddRange(uniquesUsersIds.Select(i => new Follow(loggedUserId, i)).ToList());
        }

        public async Task<IList<UserModel>> GetFollowersUsersList(Guid loggedUserId)
        {
            var followedList = await _followRepository.GetFollowersByFollowed(loggedUserId);

            var users = followedList.Select(f => new UserModel

            {
                Id = f.Follower.Id,
                Email = f.Follower.Email,
                FullName = f.Follower.FullName
            }).ToList();
            return users;
        }

        public async Task<IList<UserModel>> GetFollowingUsersList(Guid loggedUserId)
        {
            var followingList = await _followRepository.GetFollowingByFollower(loggedUserId);
            var users = followingList.Select(f => new UserModel
            {
                Id = f.Followed.Id,
                Email = f.Followed.Email,
                FullName = f.Followed.FullName
            }).ToList();

            return users;
        }

        public async Task UnfollowUsers(Guid loggedUserId, IList<Guid> userIds)
        {
            // 1. lista curenta following
            var unfollowingList = await _followRepository.GetFollowingByFollower(loggedUserId);
            var unfollowingIdsList = unfollowingList.Select(f => f.IdUserFollowed).ToList();

            // 2.validare ids exista in tabelul de follow si tabelul de users 
            var existingUsers = await _userRepository.GetAll();
            var existingUsersIds = existingUsers.Select(u => u.Id).ToList();

            var uniquesUsersIds = userIds
                .Where(i => unfollowingIdsList.Contains(i) && existingUsersIds.Contains(i))
                .ToList()
                .Distinct();

            // 3. delete from db : tble follow
            foreach (var id in uniquesUsersIds)
            {
                var newFollowEntity = new Follow(loggedUserId, id);
                _followRepository.Delete(newFollowEntity);
                await _followRepository.SaveChanges();
            }
        }
    }
}
