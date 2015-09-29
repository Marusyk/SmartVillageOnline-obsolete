using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class DocumentType : BaseDictionary
    {        
        public string Code { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
