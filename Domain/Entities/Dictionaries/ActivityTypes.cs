using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class ActivityTypes : BaseDictionary
    {
        public ActivityTypes()
        {
            Employments = new HashSet<Employment>();
        }

        public virtual ICollection<Employment> Employments { get; set; }
    }
}
