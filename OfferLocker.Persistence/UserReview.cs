using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class UserReview
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public decimal Rate { get; set; }
        public int IdReviewer { get; set; }
        public int IdReviewed { get; set; }
        public string Type { get; set; }

        public virtual User IdReviewedNavigation { get; set; }
        public virtual User IdReviewerNavigation { get; set; }
    }
}
