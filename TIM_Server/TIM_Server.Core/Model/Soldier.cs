using System;
using System.Collections.Generic;

namespace TIM_Server.Core.Model
{
    public class Soldier : User
    {
        public Soldier(Guid id, byte[] passwordHash, byte[] passwordSalt, string role, string militaryRank,
            string firstName, string lastName, string email, string phoneNumber, string pesel, string postCode,
            string city, string street, string houseNumber) : base(id, passwordHash, passwordSalt, role, militaryRank,
            firstName, lastName, email, phoneNumber, pesel, postCode, city, street, houseNumber)
        {
        }

        public virtual Company Company { get; set; }
        public Guid? CompanyId { get; set; }

        private ISet<Request> _requests = new HashSet<Request>();
        public IEnumerable<Request> Requests => _requests;
    }
}