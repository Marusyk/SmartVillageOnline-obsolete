using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class DocumentType : BaseDictionary
    {        
        public string Code { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
