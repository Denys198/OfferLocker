using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class CampusCommunity
    {
        public CampusCommunity()
        {
            CampusCommunityReview = new HashSet<CampusCommunityReview>();
            Meetup = new HashSet<Meetup>();
            Offer = new HashSet<Offer>();
            UserCampusCommunity = new HashSet<UserCampusCommunity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Link { get; set; }
        public int IdUser { get; set; }
        public int StudentsNumber { get; set; }
        public int IdUniversity { get; set; }
        public int? IdFaculty { get; set; }

        public virtual Faculty IdFacultyNavigation { get; set; }
        public virtual University IdUniversityNavigation { get; set; }
        public virtual ICollection<CampusCommunityReview> CampusCommunityReview { get; set; }
        public virtual ICollection<Meetup> Meetup { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<UserCampusCommunity> UserCampusCommunity { get; set; }
    }
}
