using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class CityType : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<City> Cities { get; set; }
    }
}
