using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class DocumentType : BaseDictionary
    {        
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }
        public string Code { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
