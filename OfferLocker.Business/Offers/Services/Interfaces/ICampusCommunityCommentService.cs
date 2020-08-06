using OfferLocker.Business.Offers.Models.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Interfaces
{
    public interface ICampusCommunityCommentService
    {
        Task<CCCCommentModel> GetById(Guid id);
        Task<CCCCommentModel> Create(CCCCommentModel model);
    }
}
