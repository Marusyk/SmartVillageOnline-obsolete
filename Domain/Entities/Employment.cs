using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities.Dictionaries;
using System;

namespace Domain.Entities
{
    public class Employment : BaseEntity
    {
        public IdType PersonID { get; set; }

        public IdType? ActivityTypesID { get; set; }

        public IdType? CompanyID { get; set; }

        public IdType? PositionID { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public bool IsCurrent { get; set; }

        public string Description { get; set; }

        //FK
        public virtual Person Person { get; set; }
        public virtual ActivityTypes ActivityTypes { get; set; }
        public virtual Companies Company { get; set; }
        public virtual Position Position { get; set; }
    }
}
