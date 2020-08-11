using System;

namespace OfferLocker.Business.Offers.Models.Student
{
    public sealed class UpsertStudentModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Year { get; set; }
        public string Specialization { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid FacultyId { get; set; }
    }
}
