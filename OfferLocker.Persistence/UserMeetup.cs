using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class UserMeetup
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdMeetup { get; set; }

        public virtual Meetup IdMeetupNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
