using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class StreetType : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Street> Streets { get; set; }
    }
}
