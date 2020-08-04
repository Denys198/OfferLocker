using Microsoft.EntityFrameworkCore;
using OfferLocker.Entities.Commons;
using OfferLocker.Entities.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OfferLocker.Persistence.Commons
{
    public interface IFollowRepository : IRepository<Follow>
    {
        Task<IList<Follow>> GetFollowersByFollowed(Guid followedId);
        Task<IList<Follow>> GetFollowingByFollower(Guid followerId);

    }

    public class FollowRepository : Repository<Follow>, IFollowRepository
    {
        private readonly OffersContext _context;
        public FollowRepository(OffersContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IList<Follow>> GetFollowingByFollower(Guid followerId)
        {
            var followingUserIds =  await _context.Follow
                .Where(f => f.IdUserFollower == followerId)
                .Include(f => f.Followed)
                .ToListAsync();

            return followingUserIds;
        }

        public async Task<IList<Follow>> GetFollowersByFollowed(Guid followedId)
        {
            var followersUserIds = await _context.Follow
                .Where(f => f.IdUserFollowed == followedId)
                .Include(f => f.Follower)
                .ToListAsync();


            return followersUserIds;
        }
    }
}
