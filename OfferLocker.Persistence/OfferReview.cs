using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class OfferReview
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public decimal Rate { get; set; }
        public int IdOffer { get; set; }
        public int IdUser { get; set; }

        public virtual Offer IdOfferNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
