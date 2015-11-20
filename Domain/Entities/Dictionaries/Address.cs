using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class Address : BaseEntity
    {
        public int CityID { get; set; }

        public int? StreetID { get; set; }

        public int? PostCode { get; set; }

        public string BuildNr { get; set; }

        public string FlatNr { get; set; }

        //FK to City
        public virtual City City { get; set; }

        //FK to Street
        public virtual Street Street { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<House> Houses { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Person> PersonBirthAddress { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Person> PersonLiveAddress { get; set; }
    }
}
