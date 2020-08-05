using System;
using System.Collections.Generic;
using System.Text;

namespace OfferLocker.Business.Offers.Models.Faculty
{
    public sealed class UpsertFacultyModel
    {
        public string Name { get; set; }
        public Guid UniversityId { get; set; }
    }
}
