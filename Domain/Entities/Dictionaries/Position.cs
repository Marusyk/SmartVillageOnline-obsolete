using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Position : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
