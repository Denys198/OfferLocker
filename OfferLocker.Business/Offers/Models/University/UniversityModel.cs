using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.University
{
    public sealed class UniversityModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
    }
}
