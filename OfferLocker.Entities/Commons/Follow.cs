using OfferLocker.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OfferLocker.Entities.Commons
{
    public sealed class Follow : Entity
    {
        public Follow()
           : base() { }
        public Follow(Guid followerId, Guid followedId)
           : base() 
        {
            IdUserFollowed = followedId;
            IdUserFollower = followerId;
        }

        [Required]
        public Guid IdUserFollower { get; set; }
        public User Follower { get; set; }

        [Required]
        public Guid IdUserFollowed { get; set; }
        public User Followed { get; set; }

    }
}
