using OfferLocker.Business.Meetups.Models;
using OfferLocker.Business.Offers.Models.Offer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfferLocker.Business.Meetups.Services.Interfaces
{
	public interface IMeetupsService
	{
		Task<MeetupModel> Add(UpsertMeetupModel model);

		Task<PaginatedList<MeetupModel>> Get(SearchModel model);

		Task<MeetupModel> GetById(Guid id);

		Task<IList<MeetupModel>> GetByUser(Guid userId);

		Task Update(Guid id, UpsertMeetupModel model);

		Task Delete(Guid id);
	}
}
