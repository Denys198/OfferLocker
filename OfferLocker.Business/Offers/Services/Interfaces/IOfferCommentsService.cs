using OfferLocker.Business.Offers.Models.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface IOfferCommentsService
    {
        Task<IEnumerable<OfferCommentModel>> Get(Guid offerId);

        Task<OfferCommentModel> Add(Guid offerId, CreateOfferCommentModel model);

        Task Delete(Guid offerId, Guid commentId);
    }
}
