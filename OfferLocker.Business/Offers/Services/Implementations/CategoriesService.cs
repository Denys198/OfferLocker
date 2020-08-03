using AutoMapper;
using Microsoft.AspNetCore.Http;
using OfferLocker.Business.Offers.Models.Category;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Offers;
using OfferLocker.Persistence.Offers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Offers.Services.Implementations
{
	public sealed class CategoriesService : ICategoriesService
	{
		private readonly IOffersRepository _repository;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _accessor;

		public CategoriesService(IOffersRepository repository, IMapper mapper, IHttpContextAccessor accessor)
		{
			_repository = repository;
			_mapper = mapper;
			_accessor = accessor;
		}

		public async Task<IEnumerable<CategoryModel>> Get(Guid offerId)
		{
			var offer = await _repository.GetByIdWithCategories(offerId);

			return _mapper.Map<IEnumerable<CategoryModel>>(offer.Categories);
		}

		public async Task<CategoryModel> Add(Guid offerId, CreateCategoryModel model)
		{
			var category = _mapper.Map<Category>(model);
			var offer = await _repository.GetById(offerId);

			offer.AddCategory(category);

			_repository.Update(offer);
			await _repository.SaveChanges();

			return _mapper.Map<CategoryModel>(category);
		}

		public async Task Delete(Guid offerId, Guid categoryId)
		{
			var offer = await _repository.GetByIdWithCategories(offerId);

			offer.RemoveCategory(categoryId);
			_repository.Update(offer);

			await _repository.SaveChanges();
		}
	}
}
