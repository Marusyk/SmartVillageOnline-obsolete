using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Entities.Dictionaries;

namespace Domain.Entities
{
    public class Catalog : BaseDictionary
    {
        public int? ParentId { get; set; }

        public int? ModuleId { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
