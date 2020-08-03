using Microsoft.AspNetCore.Http;

namespace OfferLocker.Business.Offers.Models.Photo
{
    public sealed class CreatePhotoModel
    {
        public IFormFile Content { get; set; }
    }
}
