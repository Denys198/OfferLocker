using System;

namespace OfferLocker.Business.Offers.Models.Faculty
{
    public sealed class UpsertFacultyModel
    {
        public string Name { get; set; }
        public Guid UniversityId { get; set; }
    }
}
