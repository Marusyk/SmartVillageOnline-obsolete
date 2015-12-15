using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class Region : BaseDictionary
    {
        public int CountryID { get; set; }

        // FK to Country
        public virtual Country Country { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<District> Districts { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<City> Cities { get; set; }
    }
}
