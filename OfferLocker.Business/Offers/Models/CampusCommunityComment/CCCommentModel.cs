
using System;

namespace OfferLocker.Business.Offers.Models.Comment
{
    public sealed class CCCCommentModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }
    }
}
