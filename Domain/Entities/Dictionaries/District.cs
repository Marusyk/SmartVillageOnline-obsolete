using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class District : BaseDictionary
    {
        public int RegionID { get; set; }

        // FK to Region
        [IgnoreDataMember]
        public virtual Region Regions { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<City> Cities { get; set; }
    }
}
