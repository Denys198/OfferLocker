using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class Follow
    {
        public int Id { get; set; }
        public int IdUserFollower { get; set; }
        public int IdUserFollowed { get; set; }

        public virtual User IdUserFollowedNavigation { get; set; }
        public virtual User IdUserFollowerNavigation { get; set; }
    }
}
