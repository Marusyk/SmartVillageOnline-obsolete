using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class CityType : BaseDictionary
    {
        public CityType()
        {
            Cities = new HashSet<City>();
        }

        public virtual ICollection<City> Cities { get; set; }
    }
}
