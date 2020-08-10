using AutoMapper;
using OfferLocker.Business.Offers.Models.Photo;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Offers;
using OfferLocker.Persistence.Offers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public sealed class PhotosService : IPhotosService
    {
        private readonly IMapper _mapper;
        private readonly IOffersRepository _repository;

        public PhotosService(IOffersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PhotoModel> Add(Guid offerId, CreatePhotoModel model)
        {
            var offer = await _repository.GetById(offerId);

            using var stream = new MemoryStream();
            await model.Content.CopyToAsync(stream);
            var photo = new Photo(model.Content.FileName, stream.ToArray());

            offer.Photos.Add(photo);

            _repository.Update(offer);

            await _repository.SaveChanges();

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<PhotoModel> GetById(Guid offerId, Guid photoId)
        {
            var offer = await _repository.GetByIdWithPhotos(offerId);

            var photo = offer.Photos.FirstOrDefault(p => p.Id == photoId);

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<IEnumerable<PhotoModel>> Get(Guid offerId)
        {
            var offer = await _repository.GetByIdWithPhotos(offerId);

            return _mapper.Map<IEnumerable<PhotoModel>>(offer.Photos);
        }
    }
}
