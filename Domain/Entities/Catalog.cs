using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Catalog : BaseDictionary
    {
        public Catalog()
        {
            Persons = new HashSet<Person>();
        }

        public int? ParentId { get; set; }

        public int? ModuleId { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
