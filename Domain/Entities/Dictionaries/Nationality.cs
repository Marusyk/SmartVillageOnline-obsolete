using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Nationality : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
