using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class Companies : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
