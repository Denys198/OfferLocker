using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OfferLocker.Business.Offers.Models.Comment
{
    public sealed class CreateCommentModel
    {
        public string Content { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
