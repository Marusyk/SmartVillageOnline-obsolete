using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class Nationality : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
