using AutoMapper;
using Microsoft.AspNetCore.Http;
using OfferLocker.Business.Offers.Models.Comment;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Offers;
using OfferLocker.Persistence.Commons;
using OfferLocker.Persistence.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
	public sealed class CampusCommunityComentService : ICampusCommunityCommentService
	{
		private readonly ICampusCommunityRepository _repository;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _accessor;

		public CampusCommunityComentService(ICampusCommunityRepository repository, IMapper mapper, IHttpContextAccessor accessor)
		{
			_repository = repository;
			_mapper = mapper;
			_accessor = accessor;
		}

		public async Task <CCCCommentModel> Create(CCCCommentModel model)
		{
            model.Id = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "id").Value);
			var comment = _mapper.Map<CCCCommentModel>(model);
			var campuscommunity = await _repository.GetById(model.Id);
			
			//campuscommunity.Add(comment);

			_repository.Update(campuscommunity);
			await _repository.SaveChanges();

			return _mapper.Map<CCCCommentModel>(comment);
		}

        public Task<CCCCommentModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}