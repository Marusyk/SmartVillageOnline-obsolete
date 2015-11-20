using Domain.Abstract;
using Domain.Concrete;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class City : BaseDictionary
    {
        public IdType CityTypeID { get; set; }

        public IdType? DistrictID { get; set; }

        public IdType RegionID { get; set; }

        // FK to CityType
        public virtual CityType CityType { get; set; }
        // FK to District
        public virtual District District { get; set; }
        // FK to Region
        public virtual Region Region { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Address> Addresses { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Institution> Institution { get; set; }
    }
}
