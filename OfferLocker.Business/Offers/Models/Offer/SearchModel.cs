using LinqBuilder.OrderBy;

namespace OfferLocker.Business.Offers.Models.Offer
{
    public sealed class SearchModel
    {
        public string SortColumn { get; set; } = "Name";

        public Sort SortType { get; set; } = Sort.Descending;

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
