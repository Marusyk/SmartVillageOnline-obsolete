using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Document : BaseDictionary
    {
        public int? DocumentTypeID { get; set; }

        public int? PassAuthorityID { get; set; }

        public string Number { get; set; }

        public string Code { get; set; }

        public bool State { get; set; }

        public DateTime DateReg { get; set; }

        //FK
        public virtual DocumentType DocumentType { get; set; }
        public virtual PassAuthority PassAuthority { get; set; }
    }
}
