using AutoMapper;
using OfferLocker.Business.Meetups.Models;
using OfferLocker.Entities.Meetup;

namespace OfferLocker.Business.Meetups
{
	public class MeetupsMappingProfile : Profile
	{
		public MeetupsMappingProfile()
		{
			CreateMap<UpsertMeetupModel, Meetup>();
			CreateMap<Meetup, MeetupModel>();
		}
	}
}
