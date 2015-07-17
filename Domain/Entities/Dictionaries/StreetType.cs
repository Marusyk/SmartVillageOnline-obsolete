using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class StreetType : BaseDictionary
    {
        //public StreetType()
        //{
        //    Streets = new HashSet<Street>();
        //}

        public virtual ICollection<Street> Streets { get; set; }
    }
}
