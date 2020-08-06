using AutoMapper;
using OfferLocker.Business.Categories.Models;
using OfferLocker.Business.Categories.Services.Interfaces;
using OfferLocker.Business.Offers.Extensions;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Entities.Category;
using OfferLocker.Persistence.Categories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Categories.Services.Implementations
{
	public sealed class CategoriesService : ICategoriesService
	{
		private readonly ICategoriesRepository _repository;
		private readonly IMapper _mapper;

		public CategoriesService(ICategoriesRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<CategoryModel> Add(UpsertCategoryModel model)
		{
			var category = _mapper.Map<Category>(model);

			await _repository.Add(category);
			await _repository.SaveChanges();

			return _mapper.Map<CategoryModel>(category);
		}

		public async Task<PaginatedList<CategoryModel>> Get(SearchModel model)
		{
			var spec = model.ToSpecification<Category>();

			var entities = await _repository.Get(spec);
			var count = await _repository.CountAsync();

			return new PaginatedList<CategoryModel>(
				model.PageIndex,
				entities.Count,
				count,
				_mapper.Map<IList<CategoryModel>>(entities));
		}

		public async Task<CategoryModel> GetById(Guid id)
		{
			var entity = await _repository.GetById(id);

			var category = _mapper.Map<CategoryModel>(entity);

			return category;
		}

		public async Task Update(Guid id, UpsertCategoryModel model)
		{
			var category = await _repository.GetById(id);

			category.Update(model.Name, model.Description);

			_repository.Update(category);
			await _repository.SaveChanges();
		}

		public async Task Delete(Guid id)
		{
			var category = await _repository.GetById(id);

			_repository.Delete(category);
			await _repository.SaveChanges();
		}
	}
}
