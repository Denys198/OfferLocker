using AutoMapper;
using OfferLocker.Business.Offers.Models.CampusCommunity;
using OfferLocker.Business.Offers.Models.Comment;
using OfferLocker.Business.Offers.Models.Faculty;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Models.Photo;
using OfferLocker.Business.Offers.Models.Student;
using OfferLocker.Business.Offers.Models.University;
using OfferLocker.Business.Offers.Models.UserType;
using OfferLocker.Entities.Commons;
using OfferLocker.Entities.Identity;
using OfferLocker.Entities.Offers;

namespace OfferLocker.Business.Offers
{
	public class OffersMappingProfile : Profile
	{
		public OffersMappingProfile()
		{
			CreateMap<UpsertOfferModel, Offer>();
			CreateMap<Offer, OfferModel>();

			CreateMap<CreateCommentModel, Comment>();
			CreateMap<Comment, CommentModel>();

			CreateMap<PhotoModel, Photo>();
			CreateMap<Photo, PhotoModel>();

			CreateMap<University, UniversityModel>();
			CreateMap<Faculty, FacultyModel>();
			CreateMap<Student, StudentModel>();
			CreateMap<CampusCommunity, CampusCommunityModel>();
			CreateMap<UserType, UserTypeModel>();
		}
	}
}
