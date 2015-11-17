using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Position : BaseDictionary
    {
        public Position()
        {
            Employments = new HashSet<Employment>();
        }

        public virtual ICollection<Employment> Employments { get; set; }
    }
}
