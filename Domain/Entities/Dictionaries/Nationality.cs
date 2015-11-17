using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Nationality : BaseDictionary
    {
        public Nationality()
        {
            Persons = new HashSet<Person>();
        }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
