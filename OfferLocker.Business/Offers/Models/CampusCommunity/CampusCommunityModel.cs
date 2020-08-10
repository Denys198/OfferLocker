using System;

namespace OfferLocker.Business.Offers.Models.CampusCommunity
{
    public sealed class CampusCommunityModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public byte[] Image { get; private set; }
        public string Link { get; private set; }
        public int StudentsNumber { get; private set; }
        public Guid IdUser { get; private set; }
    }
}
