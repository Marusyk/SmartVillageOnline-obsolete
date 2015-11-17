using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class FamilyStatus : BaseDictionary
    {
        public FamilyStatus()
        {
            Persons = new HashSet<Person>();
        }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
