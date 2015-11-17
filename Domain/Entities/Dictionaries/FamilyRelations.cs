using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class FamilyRelations : BaseDictionary
    {
        public FamilyRelations()
        {
            Peoples = new HashSet<People>();
        }

        public virtual ICollection<People> Peoples { get; set; }
    }
}
