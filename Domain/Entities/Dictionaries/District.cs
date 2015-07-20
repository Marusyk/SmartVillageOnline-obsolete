using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Entities.Dictionaries
{
    public class District : BaseDictionary
    {
        public int RegionID { get; set; }

        // FK to Region
        public virtual Region Regions { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
