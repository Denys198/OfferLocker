using System;

namespace OfferLocker.Business.Meetups.Models
{
	public sealed class UpsertMeetupModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime Date { get; set; }
	}
}
