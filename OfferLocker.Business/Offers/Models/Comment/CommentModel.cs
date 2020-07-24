using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.Comment
{
    public sealed class CommentModel
    {
        public Guid Id { get; private set; }

        public string Content { get; private set; }

        public Guid UserId { get; private set; }
    }
}
