using OfferLocker.Business.Offers.Models.SavedOffer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface ISavedOfferService
    {
        Task<SavedOfferModel> Add(CreateSavedOfferModel model);
        Task Delete(Guid id);
    }
}
