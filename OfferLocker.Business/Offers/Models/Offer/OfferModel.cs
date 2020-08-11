using System;

namespace OfferLocker.Business.Offers.Models.Offer
{
    public sealed class OfferModel
	{
		public Guid Id { get; private set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public float Price { get; set; }

		public Guid CategoryId { get; private set; }

		public Guid UserId { get; private set; }
	}
}
