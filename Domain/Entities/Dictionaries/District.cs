using Domain.Abstract;
using Domain.Concrete;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class District : BaseDictionary
    {
        public IdType RegionID { get; set; }

        // FK to Region        
        public virtual Region Region { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<City> Cities { get; set; }
    }
}
