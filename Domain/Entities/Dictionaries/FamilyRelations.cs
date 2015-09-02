using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class FamilyRelations : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<People> Peoples { get; set; }
    }
}
