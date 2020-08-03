using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.Faculty
{
    public sealed class CreateFacultyModel
    {
        public string Name { get; private set; }
        public Guid UniversityId { get; private set; }
    }
}
