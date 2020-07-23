using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class CampusCommunityReview
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public decimal Rate { get; set; }
        public int IdCampusCommunity { get; set; }
        public int IdUser { get; set; }

        public virtual CampusCommunity IdCampusCommunityNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
