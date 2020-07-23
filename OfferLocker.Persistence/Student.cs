using System;
using System.Collections.Generic;

namespace OfferLocker.Persistence
{
    public partial class Student
    {
        public Student()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Age { get; set; }
        public decimal Year { get; set; }
        public string Specialization { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int IdFaculty { get; set; }

        public virtual Faculty IdFacultyNavigation { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
