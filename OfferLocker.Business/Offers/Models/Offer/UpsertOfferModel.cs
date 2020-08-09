using System;

namespace OfferLocker.Business.Offers.Models.Offer
{
	public sealed class UpsertOfferModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public float Price { get; set; }

		public Guid CategoryId { get; set; }

		public Guid UserId { get; set; }

	}
}
