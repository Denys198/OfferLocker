using System;

namespace OfferLocker.Business.Meetups.Models
{
	public sealed class MeetupModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime Date { get; set; }
	}
}
