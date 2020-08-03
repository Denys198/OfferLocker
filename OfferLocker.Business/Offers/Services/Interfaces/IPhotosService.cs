using OfferLocker.Business.Offers.Models.Photo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IPhotosService
    {
        Task<PhotoModel> Add(Guid offerId, CreatePhotoModel model);

        Task<PhotoModel> GetById(Guid offerId, Guid photoId);

        Task<IEnumerable<PhotoModel>> Get(Guid tripId);
    }
}
