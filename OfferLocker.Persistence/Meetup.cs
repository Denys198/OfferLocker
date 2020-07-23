using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class Meetup
    {
        public Meetup()
        {
            UserMeetup = new HashSet<UserMeetup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public int IdCampusCommunity { get; set; }

        public virtual CampusCommunity IdCampusCommunityNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<UserMeetup> UserMeetup { get; set; }
    }
}
