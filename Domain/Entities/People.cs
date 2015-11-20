using Domain.Abstract;
using Domain.Concrete;
using System;

namespace Domain.Entities
{
    public class People : BaseEntity
    {
        public IdType PersonID { get; set; }

        public IdType HouseID { get; set; }

        public int PeopleNumber { get; set; }

        public IdType? FamilyRelationID { get; set; }

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
