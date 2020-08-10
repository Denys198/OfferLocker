using LinqBuilder.Core;
using LinqBuilder.OrderBy;
using OfferLocker.Business.Offers.Models.Offer;
using OfferLocker.Entities;
using System;
using System.Linq.Expressions;

namespace OfferLocker.Business.Offers.Extensions
{
	public static class SearchModelExtensions
	{
		public static ISpecification<T> ToSpecification<T>(this SearchModel model) where T : Entity
		{
			var parameterExpression = Expression.Parameter(typeof(T));

			var memberExpression = Expression.Property(parameterExpression, model.SortColumn);

			var expression = Expression.Convert(memberExpression, typeof(object));

			var lambda = Expression.Lambda<Func<T, object>>(expression, parameterExpression);

			return OrderSpec<T, object>
				.New(lambda, model.SortType)
				.Paginate(model.PageIndex, model.PageSize);
		}
	}
}
