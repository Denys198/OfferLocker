using OfferLocker.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OfferLocker.Entities.Commons
{
    public sealed class Follow : Entity
    {
        public Follow()
           : base() { }

        [Required]
        public Guid IdUserFollower { get; set; }
        public User Follower { get; set; }

        [Required]
        public Guid IdUserFollowed { get; set; }
        public User Followed { get; set; }

    }
}
