using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OfferLocker.Business.Offers.Extensions;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Entities.Offers;
using OfferLocker.Persistence.Offers;

namespace OfferLocker.Business.Offers.Services.Implementations
{
	public sealed class OffersService : IOffersService
	{
		private readonly IOffersRepository _repository;
		private readonly IMapper _mapper;

		public OffersService(IOffersRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<OfferModel> Add(UpsertOfferModel model)
		{
			var offer = _mapper.Map<Offer>(model);

			await _repository.Add(offer);
			await _repository.SaveChanges();

			return _mapper.Map<OfferModel>(offer);
		}

		public async Task<PaginatedList<OfferModel>> Get(SearchModel model)
		{
			var spec = model.ToSpecification<Offer>();

			var entities = await _repository.Get(spec);
			var count = await _repository.CountAsync();

			return new PaginatedList<OfferModel>(
				model.PageIndex,
				entities.Count,
				count,
				_mapper.Map<IList<OfferModel>>(entities));
		}

		public async Task<IList<OfferModel>> GetByCategory(Guid categoryId)
		{
			var entities = await _repository.GetByCategory(categoryId);
			return _mapper.Map<IList<OfferModel>>(entities);
		}

		public async Task<IList<OfferModel>> GetByUser(Guid userId)
		{
			var entities = await _repository.GetByUser(userId);
			return _mapper.Map<IList<OfferModel>>(entities);
		}

		public async Task<OfferModel> GetById(Guid id)
		{
			var entity = await _repository.GetById(id);

			var offer = _mapper.Map<OfferModel>(entity);

			return offer;
		}

		public async Task Update(Guid id, UpsertOfferModel model)
		{
			var offer = await _repository.GetById(id);

			offer.Update(model.Name, model.Description, model.Price, model.CategoryId);

			_repository.Update(offer);
			await _repository.SaveChanges();
		}

		public async Task Delete(Guid id)
		{
			var offer = await _repository.GetById(id);

			_repository.Delete(offer);
			await _repository.SaveChanges();
		}
	}
}
