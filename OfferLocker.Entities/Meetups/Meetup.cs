using System;
using System.ComponentModel.DataAnnotations;

namespace OfferLocker.Entities.Meetup
{
    public sealed class Meetup : Entity
	{
        public Meetup(string name, string description, DateTime date, Guid userId) : base()
        {
            Name = name;

            Description = description;

            Date = date;

            UserId = userId;
        }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }

        public void Update(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }
    }
}
