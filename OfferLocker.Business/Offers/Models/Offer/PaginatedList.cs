using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.Offer
{
    public sealed class PaginatedList<T>
    {
        private PaginatedList() { }

        public PaginatedList(int pageIndex, int pageSize, int count, IList<T> results) : base()
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Results = results;
        }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int Count { get; private set; }

        public IList<T> Results { get; private set; }
    }
}
