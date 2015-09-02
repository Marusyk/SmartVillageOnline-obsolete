using Domain.Abstract;
using System;

namespace Domain.Entities
{
    public class People : BaseEntity
    {
        public int PersonID { get; set; }

        public int HouseID { get; set; }

        public int PeopleNumber { get; set; }

        public int? FamilyRelationID { get; set; }

        public DateTime? DateRegistration { get; set; }

        public bool IsMain { get; set; }

        //FK to House
        public virtual House Houses { get; set; }

        //FK to Person
        public virtual Person Persons { get; set; }

        //FK to FamilyRelations
        public virtual FamilyRelations FamilyRelations { get; set; }
    }
}
