using Domain.Abstract;
using Domain.Entities.Dictionaries;


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
