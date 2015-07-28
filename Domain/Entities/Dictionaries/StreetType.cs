using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class StreetType : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Street> Streets { get; set; }
    }
}
