using OfferLocker.Business.Identity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IFollowService
    {
        Task FollowUsers(Guid loggedUserId, IList<Guid> userIds);
        Task UnfollowUsers(Guid loggedUserId, IList<Guid> userIds);

        Task<IList<UserModel>> GetFollowingUsersList(Guid loggedUserId);
        Task<IList<UserModel>> GetFollowersUsersList(Guid loggedUserId);
    }
}
