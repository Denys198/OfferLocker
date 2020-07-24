using OfferLocker.Business.Offers.Models.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentModel>> Get(Guid tripId);

        Task<CommentModel> Add(Guid tripId, CreateCommentModel model);

        Task Delete(Guid tripId, Guid commentId);
    }
}
