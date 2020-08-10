using System;

namespace OfferLocker.Business.Offers.Models.Student
{
    public sealed class StudentModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Year { get; private set; }
        public string Specialization { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public Guid FacultyId { get; private set; }
    }
}
