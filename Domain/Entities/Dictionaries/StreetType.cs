using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class StreetType : BaseDictionary
    {
        public ICollection<Street> Street { get; set; }
    }
}
