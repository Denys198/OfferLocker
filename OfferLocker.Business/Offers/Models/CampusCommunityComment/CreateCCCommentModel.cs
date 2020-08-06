
using System;
using System.Text.Json.Serialization;

namespace OfferLocker.Business.Offers.Models.CampusCommunityComment
{
   public sealed class CreateCCCommentModel
    {
        public string Content { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
