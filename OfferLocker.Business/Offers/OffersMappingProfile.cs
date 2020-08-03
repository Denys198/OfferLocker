using AutoMapper;
using OfferLocker.Business.Offers.Models.Category;
using OfferLocker.Business.Offers.Models.Comment;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Business.Offers.Models.Photo;
using OfferLocker.Entities.Offers;

namespace OfferLocker.Business.Offers
{
	public class OffersMappingProfile : Profile
	{
		public OffersMappingProfile()
		{
			CreateMap<UpsertOfferModel, Offer>();
			CreateMap<Offer, OfferModel>();

			CreateMap<CreateOfferCommentModel, OfferComment>();
			CreateMap<OfferComment, OfferCommentModel>();

			CreateMap<PhotoModel, Photo>();
			CreateMap<Photo, PhotoModel>();

			CreateMap<CreateCategoryModel, Category>();
			CreateMap<Category, CategoryModel>();
		}
	}
}
