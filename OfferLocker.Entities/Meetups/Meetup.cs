using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Entities.Meetup
{
	public sealed class Meetup : Entity
	{
        public Meetup(string name, string description, DateTime date) : base()
        {
            Name = name;

            Description = description;

            Date = date;
        }

        public string Name { get; private set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public void Update(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }
    }
}
