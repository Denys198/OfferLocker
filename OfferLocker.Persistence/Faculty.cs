using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class Faculty
    {
        public Faculty()
        {
            CampusCommunity = new HashSet<CampusCommunity>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdUniversity { get; set; }

        public virtual University IdUniversityNavigation { get; set; }
        public virtual ICollection<CampusCommunity> CampusCommunity { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
