using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CityType : BaseDictionary
    {
        public virtual ICollection<City> Cities { get; set; }
    }
}
