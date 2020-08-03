using System.Collections.Generic;

using OfferLocker.Entities.Identity;

namespace OfferLocker.Entities.Commons
{
    public sealed class Faculty : Entity
    {
        public Faculty(string name):base()
        {            
            Name = name;
        }
        public string Name { get; set; }
        public ICollection<Student> Students { get; private set; }
        public ICollection<CampusCommunity> CampusCommunities { get; private set; }
    }
}
