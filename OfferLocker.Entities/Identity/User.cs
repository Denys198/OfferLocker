using OfferLocker.Entities.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfferLocker.Entities.Identity
{
    public class User : Entity
    {
        public User(string fullName, string email, string passwordHash)
            : base()
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
        }

        [Required]
        public string FullName { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        public string PasswordHash { get; private set; }

        public virtual IList<Follow> Followers { get; set; }
        public virtual IList<Follow> Following { get; set; }
        public ICollection<NotificationsToUsers> Notifications { get; private set; }
        public ICollection<SavedOffer> SavedOffers { get; set; }
    }
}
