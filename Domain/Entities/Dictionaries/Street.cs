using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Street : BaseDictionary
    {       
        public int StreetTypeID { get; set; }

        // create foreign key using Lazy Load (virtual)    
        public virtual StreetType StreetType { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
