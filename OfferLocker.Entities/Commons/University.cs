using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Entities.Commons
{
    public sealed class University : Entity
    {
        public University(string name, string city) : base()
        {
            Name = name;
            City = city;
        }
        public string Name { get; private set; }
        public string City { get; private set; }
        public ICollection<Faculty> Faculties { get; private set; }
        public ICollection<CampusCommunity> CampusCommunities { get; private set; }
        public void Update(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }
    }
}
