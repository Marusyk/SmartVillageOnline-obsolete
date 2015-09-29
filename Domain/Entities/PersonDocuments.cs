using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonDocuments : BaseEntity
    {
        public int PersonID { get; set; }

        public int DocumentID { get; set; }

        //FK
        public virtual Person Person { get; set; }
        public virtual Document Document { get; set; }
    }
}
