using System;
using System.Collections.Generic;
using System.Linq;

namespace OfferLocker.Entities.Offers
{
	public sealed class Offer : Entity
	{
		public Offer(string name, string description, float price, Guid categoryId) : base()
		{
			Name = name;
			Description = description;
			Price = price;
			CategoryId = categoryId;
			Photos = new List<Photo>();
			Comments = new List<OfferComment>();
		}

		public string Name { get; set; }

		public string Description { get; set; }

		public float Price { get; set; }

		public Guid CategoryId { get; set; }

		public ICollection<Photo> Photos { get; private set; }

		public ICollection<OfferComment> Comments { get; private set; }

		public void AddComment(OfferComment comment)
		{
			this.Comments.Add(comment);
		}

		public void RemoveComment(Guid commentId)
		{
			var comment = this.Comments.FirstOrDefault(c => c.Id == commentId);

			if (comment != null)
			{
				this.Comments.Remove(comment);
			}
		}

		public void Update(string name, string description, float price, Guid categoryId)
		{
			Name = name;
			Description = description;
			Price = price;
			CategoryId = categoryId;
		}
	}
}
