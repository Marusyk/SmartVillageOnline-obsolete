using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Catalog : BaseEntity
    {
        public int? ParentId { get; set; }

        public string Name { get; set; }

        public int? ModuleId { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
