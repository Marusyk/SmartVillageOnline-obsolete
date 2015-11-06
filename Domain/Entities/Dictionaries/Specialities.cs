using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class Specialities : BaseDictionary
    {
        public Specialities()
        {
            Educations = new HashSet<Education>();
        }

        public virtual ICollection<Education> Educations { get; set; }
    }
}
