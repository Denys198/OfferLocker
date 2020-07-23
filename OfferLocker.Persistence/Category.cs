using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class Category
    {
        public Category()
        {
            Offer = new HashSet<Offer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
    }
}
