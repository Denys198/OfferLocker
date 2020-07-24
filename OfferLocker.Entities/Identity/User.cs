using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OfferLocker.Entities.Identity
{
    public sealed class User : Entity
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
    }
}
