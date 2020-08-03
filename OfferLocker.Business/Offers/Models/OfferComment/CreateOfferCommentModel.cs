using System;
using System.Text.Json.Serialization;

namespace OfferLocker.Business.Offers.Models.Comment
{
    public sealed class CreateOfferCommentModel
    {
        public string Content { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
