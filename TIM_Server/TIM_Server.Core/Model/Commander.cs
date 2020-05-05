using System;

namespace TIM_Server.Core.Model
{
    public class Commander : User
    {
        public Commander(Guid id, byte[] passwordHash, byte[] passwordSalt, string role, string militaryRank,
            string firstName, string lastName, string email, string phoneNumber, string pesel, string postCode,
            string city, string street, string houseNumber) : base(id, passwordHash, passwordSalt, role, militaryRank,
            firstName, lastName, email, phoneNumber, pesel, postCode, city, street, houseNumber)
        {
        }

        public virtual Company Company { get; set; }
        public Guid? CompanyId { get; set; }

    }
}