using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class PassAuthority : BaseDictionary
    {
        public PassAuthority()
        {
            Persons = new HashSet<Person>();
            Documents = new HashSet<Document>();
        }

        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
