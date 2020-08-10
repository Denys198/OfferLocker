using System;

namespace OfferLocker.Business.Offers.Models.Faculty
{
    public sealed class FacultyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UniversityId { get; set; }
    }
}
