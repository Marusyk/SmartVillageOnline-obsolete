using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Country : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Region> Regions { get; set; }
    }
}
