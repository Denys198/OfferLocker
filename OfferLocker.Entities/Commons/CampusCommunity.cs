using OfferLocker.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OfferLocker.Entities.Commons
{
    public sealed class CampusCommunity : Entity
    {
        public CampusCommunity(string name, string description, byte[] image, string link, int studentsNumber, Guid idUser)
            : base()
        {
            Name = name;
            Description = description;
            Image = image;
            Link = link;
            StudentsNumber = studentsNumber;
            IdUser = idUser;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Link { get; set; }
        public int StudentsNumber { get; set; }
        public Guid IdUser { get; set; }

        public ICollection<User> Users { get; private set; }

        public void Update(string name, string description, byte[] image, string link, int studentsNumber, Guid idUser)
        {
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.Link = link;
            this.StudentsNumber = studentsNumber;
            this.IdUser = idUser;
        }
    }
}
