using System;

namespace OfferLocker.Business.Categories.Models
{
    public sealed class CategoryModel
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
