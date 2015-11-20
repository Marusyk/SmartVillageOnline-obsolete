using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class Position : BaseDictionary
    {
        [IgnoreDataMember]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
