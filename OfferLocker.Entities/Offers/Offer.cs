using System;
using System.Collections.Generic;
using System.Linq;

namespace OfferLocker.Entities.Offers
{
	public sealed class Offer : Entity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public ICollection<Photo> Photos { get; private set; }

		public ICollection<Comment> Comments { get; private set; }

		public Offer(string name, string description) : base()
		{
			Name = name;
			Description = description;
			Photos = new List<Photo>();
			Comments = new List<Comment>();
		}

		public void AddComment(Comment comment)
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

		public void Update(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}
