using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class StreetType : BaseDictionary
    {
        public StreetType()
        {
            Streets = new HashSet<Street>();
        }

        [IgnoreDataMember]
        public virtual ICollection<Street> Streets { get; set; }
    }
}
