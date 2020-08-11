namespace OfferLocker.Entities.Identity
{
    public sealed class Student : Entity
    {
        public Student(string name, int age, int year, string specialization, int phoneNumber, string email)
            : base()
        {
            Name = name;
            Age = age;
            Year = year;
            Specialization = specialization;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Year { get; set; }
        public string Specialization { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public void Update(string name, int age, int year, string specialization, int phoneNumber, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Year = year;
            this.Specialization = specialization;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
    }
}
