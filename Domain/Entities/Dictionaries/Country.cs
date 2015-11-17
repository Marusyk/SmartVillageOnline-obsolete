using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Country : BaseDictionary
    {
        public Country()
        {
            Regions = new HashSet<Region>();
            Persons = new HashSet<Person>();
        }

        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
