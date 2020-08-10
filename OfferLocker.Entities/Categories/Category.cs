using System.ComponentModel.DataAnnotations;

namespace OfferLocker.Entities.Category
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

		public void Update(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}
