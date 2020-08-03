using System;

namespace OfferLocker.Business.Offers.Models.Comment
{
    public sealed class OfferCommentModel
    {
        public Guid Id { get; private set; }

        public string Content { get; private set; }

        public Guid UserId { get; private set; }
    }
}
