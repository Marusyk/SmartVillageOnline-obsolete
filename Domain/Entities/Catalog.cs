using Domain.Abstract;
using Domain.Concrete;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Catalog : BaseDictionary
    {
        public IdType? ParentId { get; set; }

        public IdType? ModuleId { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
