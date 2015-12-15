using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class PassAuthority : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Person> Persons { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
