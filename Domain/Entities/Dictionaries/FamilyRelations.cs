using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class FamilyRelations : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<People> Peoples { get; set; }
    }
}
