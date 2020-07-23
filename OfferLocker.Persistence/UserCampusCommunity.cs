using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class UserCampusCommunity
    {
        public int Id { get; set; }
        public int IdCampusCommunity { get; set; }
        public int IdUser { get; set; }

        public virtual CampusCommunity IdCampusCommunityNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
