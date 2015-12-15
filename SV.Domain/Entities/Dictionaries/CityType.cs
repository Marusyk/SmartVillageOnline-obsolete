using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class CityType : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<City> Cities { get; set; }
    }
}
