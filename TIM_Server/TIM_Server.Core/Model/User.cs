using System;

namespace TIM_Server.Core.Model
{
    public abstract class User
    {
        protected User()
        {
        }

        protected User(Guid id, byte[] passwordHash, byte[] passwordSalt, string role, string militaryRank,
            string firstName, string lastName, string email, string phoneNumber, string pesel, string postCode,
            string city, string street, string houseNumber)
        {
            Id = id;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Role = role;
            MilitaryRank = militaryRank;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Pesel = pesel;
            PostCode = postCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public Guid Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string MilitaryRank { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pesel { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}