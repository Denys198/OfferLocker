using AutoMapper;
using OfferLocker.Business.Meetups.Models;
using OfferLocker.Business.Meetups.Services.Interfaces;
using OfferLocker.Business.Offers.Extensions;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Entities.Meetup;
using OfferLocker.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Meetups.Services.Implementations
{
	public sealed class MeetupsService : IMeetupsService
	{
		private readonly IMeetupsRepository _repository;
		private readonly IMapper _mapper;

		public MeetupsService(IMeetupsRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<MeetupModel> Add(UpsertMeetupModel model)
		{
			var meetup = _mapper.Map<Meetup>(model);

			await _repository.Add(meetup);
			await _repository.SaveChanges();

			return _mapper.Map<MeetupModel>(meetup);
		}

		public async Task<PaginatedList<MeetupModel>> Get(SearchModel model)
		{
			var spec = model.ToSpecification<Meetup>();

			var entities = await _repository.Get(spec);
			var count = await _repository.CountAsync();

			return new PaginatedList<MeetupModel>(
				model.PageIndex,
				entities.Count,
				count,
				_mapper.Map<IList<MeetupModel>>(entities));
		}

		public async Task<MeetupModel> GetById(Guid id)
		{
			var entity = await _repository.GetById(id);

			var meetup = _mapper.Map<MeetupModel>(entity);

			return meetup;
		}

		public async Task<IList<MeetupModel>> GetByUser(Guid userId)
		{
			var entities = await _repository.GetByUser(userId);
			return _mapper.Map<IList<MeetupModel>>(entities);
		}

		public async Task Update(Guid id, UpsertMeetupModel model)
		{
			var meetup = await _repository.GetById(id);

			meetup.Update(model.Name, model.Description, model.Date);

			_repository.Update(meetup);
			await _repository.SaveChanges();
		}

		public async Task Delete(Guid id)
		{
			var meetup = await _repository.GetById(id);

			_repository.Delete(meetup);
			await _repository.SaveChanges();
		}
	}
}
