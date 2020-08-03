using System;

namespace OfferLocker.Business.Offers.Models.Category
{
    public sealed class CategoryModel
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
