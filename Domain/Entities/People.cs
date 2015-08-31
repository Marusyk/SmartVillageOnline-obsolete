using Domain.Abstract;
using System;

namespace Domain.Entities
{
    public class People : BaseEntity
    {
        public int PersonID { get; set; }

        public int HouseID { get; set; }

        public int PeopleNumber { get; set; }

        public int? FamilyRelationsId { get; set; }

        public DateTime? DateRegistration { get; set; }

        public bool IsMain { get; set; }

    }
}
