using AutoMapper;
using Microsoft.AspNetCore.Http;
using OfferLocker.Business.Offers.Models.Comment;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Offers;
using OfferLocker.Persistence.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
	public sealed class OfferCommentsService : IOfferCommentsService
	{
		private readonly IOffersRepository _repository;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _accessor;

		public OfferCommentsService(IOffersRepository repository, IMapper mapper, IHttpContextAccessor accessor)
		{
			_repository = repository;
			_mapper = mapper;
			_accessor = accessor;
		}

		public async Task<IEnumerable<OfferCommentModel>> Get(Guid offerId)
		{
			var offer = await _repository.GetByIdWithComments(offerId);

			return _mapper.Map<IEnumerable<OfferCommentModel>>(offer.Comments);
		}

		public async Task<OfferCommentModel> Add(Guid offerId, CreateOfferCommentModel model)
		{
			model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
			var comment = _mapper.Map<OfferComment>(model);
			var offer = await _repository.GetById(offerId);

			offer.AddComment(comment);

			_repository.Update(offer);
			await _repository.SaveChanges();

			return _mapper.Map<OfferCommentModel>(comment);
		}

		public async Task Delete(Guid offerId, Guid commentId)
		{
			var offer = await _repository.GetByIdWithComments(offerId);

			offer.RemoveComment(commentId);
			_repository.Update(offer);

			await _repository.SaveChanges();
		}
	}
}
