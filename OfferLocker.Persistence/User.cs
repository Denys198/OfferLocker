using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class User
    {
        public User()
        {
            CampusCommunityReview = new HashSet<CampusCommunityReview>();
            FollowIdUserFollowedNavigation = new HashSet<Follow>();
            FollowIdUserFollowerNavigation = new HashSet<Follow>();
            Meetup = new HashSet<Meetup>();
            Offer = new HashSet<Offer>();
            OfferReview = new HashSet<OfferReview>();
            UserCampusCommunity = new HashSet<UserCampusCommunity>();
            UserMeetup = new HashSet<UserMeetup>();
            UserReviewIdReviewedNavigation = new HashSet<UserReview>();
            UserReviewIdReviewerNavigation = new HashSet<UserReview>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int? IdStudent { get; set; }
        public int IdUserType { get; set; }

        public virtual Student IdStudentNavigation { get; set; }
        public virtual UserType IdUserTypeNavigation { get; set; }
        public virtual ICollection<CampusCommunityReview> CampusCommunityReview { get; set; }
        public virtual ICollection<Follow> FollowIdUserFollowedNavigation { get; set; }
        public virtual ICollection<Follow> FollowIdUserFollowerNavigation { get; set; }
        public virtual ICollection<Meetup> Meetup { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<OfferReview> OfferReview { get; set; }
        public virtual ICollection<UserCampusCommunity> UserCampusCommunity { get; set; }
        public virtual ICollection<UserMeetup> UserMeetup { get; set; }
        public virtual ICollection<UserReview> UserReviewIdReviewedNavigation { get; set; }
        public virtual ICollection<UserReview> UserReviewIdReviewerNavigation { get; set; }
    }
}
