using System.ComponentModel.DataAnnotations;

namespace OfferLocker.Entities.Offers
{
	public sealed class Category : Entity
	{
		public Category(string name, string description) : base()
		{
			Name = name;
			Description = description;
		}

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }
	}
}
