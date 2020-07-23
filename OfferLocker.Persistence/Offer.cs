using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class Offer
    {
        public Offer()
        {
            OfferReview = new HashSet<OfferReview>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public int IdCampusCommunity { get; set; }
        public string Status { get; set; }
        public int IdUser { get; set; }

        public virtual CampusCommunity IdCampusCommunityNavigation { get; set; }
        public virtual Category IdCategoryNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<OfferReview> OfferReview { get; set; }
    }
}
