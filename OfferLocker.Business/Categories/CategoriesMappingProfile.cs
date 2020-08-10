using AutoMapper;
using OfferLocker.Business.Categories.Models;
using OfferLocker.Entities.Category;

namespace OfferLocker.Business.Categories
{
	public class CategoriesMappingProfile : Profile
	{
		public CategoriesMappingProfile()
		{
			CreateMap<UpsertCategoryModel, Category>();
			CreateMap<Category, CategoryModel>();
		}
	}
}
