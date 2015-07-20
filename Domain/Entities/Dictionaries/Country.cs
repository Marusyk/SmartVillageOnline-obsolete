using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Country : BaseDictionary
    {
        public virtual ICollection<Region> Regions { get; set; }
    }
}
