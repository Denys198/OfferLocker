using AutoMapper;
using OfferLocker.Business.Offers.Models.SavedOffer;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Commons;
using OfferLocker.Persistence.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
    public class SavedOfferService :ISavedOfferService
    {
        private readonly ISavedOfferRepository repository;
        private readonly IMapper mapper;
        public SavedOfferService(ISavedOfferRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<SavedOfferModel> Add(CreateSavedOfferModel model)
        {
            var savedOffer = new SavedOffer(model.OfferId, model.UserId);

            await repository.Add(savedOffer);
            await repository.SaveChanges();

            return mapper.Map<SavedOfferModel>(savedOffer);
        }
        public async Task Delete(Guid id)
        {
            var so = await repository.GetById(id);

            repository.Delete(so);
            await repository.SaveChanges();
        }
    }
}
