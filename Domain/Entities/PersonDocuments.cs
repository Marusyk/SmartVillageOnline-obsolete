using Domain.Abstract;
using Domain.Concrete;

namespace Domain.Entities
{
    public class PersonDocuments : BaseEntity
    {
        public IdType PersonID { get; set; }

        public IdType DocumentID { get; set; }

        //FK
        public virtual Person Person { get; set; }
        public virtual Document Document { get; set; }
    }
}
