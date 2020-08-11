using System.Collections.Generic;

namespace OfferLocker.Entities.Identity
{
    public sealed class UserType : Entity
    {
        public UserType(string name, string description) : base()
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; private set; }

        public void Update(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
