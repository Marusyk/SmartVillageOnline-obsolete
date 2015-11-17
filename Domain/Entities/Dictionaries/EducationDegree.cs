using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class EducationDegree : BaseDictionary
    {
        public EducationDegree()
        {
            Educations = new HashSet<Education>();
        }

        public virtual ICollection<Education> Educations { get; set; }
    }
}
