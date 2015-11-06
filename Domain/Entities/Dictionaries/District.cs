using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class District : BaseDictionary
    {
        public District()
        {
            Cities = new HashSet<City>();
        }
        public int RegionID { get; set; }

        // FK to Region        
        public virtual Region Region { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
