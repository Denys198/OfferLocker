using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.CampusCommunity
{
    public sealed class CreateCampusCommunityModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Link { get; set; }
        public int StudentsNumber { get; set; }
        public Guid IdUser { get; set; }
    }
}
