using System;
using System.Collections.Generic;
using System.Linq;

namespace OfferLocker.Entities.Offers
{
	public sealed class Offer : Entity
	{
		public Offer(string name, string description, float price) : base()
		{
			Name = name;
			Description = description;
			Price = price;
			Photos = new List<Photo>();
			Comments = new List<OfferComment>();
			Categories = new List<Category>();
		}

		public string Name { get; set; }

		public string Description { get; set; }

		public float Price { get; set; }

		public ICollection<Photo> Photos { get; private set; }

		public ICollection<OfferComment> Comments { get; private set; }

		public ICollection<Category> Categories { get; private set; }

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

		public void AddCategory(Category category)
		{
			this.Categories.Add(category);
		}

		public void RemoveCategory(Guid categoryId)
		{
			var category = this.Categories.FirstOrDefault(c => c.Id == categoryId);

			if (category != null)
			{
				this.Categories.Remove(category);
			}
		}

		public void Update(string name, string description, float price)
		{
			Name = name;
			Description = description;
			Price = price;
		}
	}
}
