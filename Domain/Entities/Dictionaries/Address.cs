using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System.Runtime.Serialization;

namespace Domain.Entities
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

    }
}
