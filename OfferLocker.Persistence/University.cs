using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class University
    {
        public University()
        {
            CampusCommunity = new HashSet<CampusCommunity>();
            Faculty = new HashSet<Faculty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<CampusCommunity> CampusCommunity { get; set; }
        public virtual ICollection<Faculty> Faculty { get; set; }
    }
}
