using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class Region : BaseDictionary
    {
        public Region()
        {
            Districts = new HashSet<District>();
            Cities = new HashSet<City>();
        }
        public int CountryID { get; set; }

        // FK to Country
        public virtual Country Country { get; set; }

        public virtual ICollection<District> Districts { get; set; }       
        public virtual ICollection<City> Cities { get; set; }
    }
}
