using System;

namespace OfferLocker.Business.Offers.Models.UserType
{
    public sealed class UserTypeModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
