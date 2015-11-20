using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class Country : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Region> Regions { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
