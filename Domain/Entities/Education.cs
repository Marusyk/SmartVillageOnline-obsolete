using Domain.Abstract;
using Domain.Concrete;

namespace Domain.Entities.Dictionaries
{
    public class Education : BaseEntity
    {
        public IdType PersonID { get; set; }

        public IdType InstitutionID { get; set; }

        public IdType? SpecialitiesID { get; set; }

        public IdType? EducationDegreeID { get; set; }

        public int? StartYear { get; set; }

        public int? EndYear { get; set; }

        public IdType? DocumentID { get; set; }

        public string Description { get; set; }

        //FK
        public virtual Person Person { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual Specialities Specialities { get; set; }
        public virtual EducationDegree EducationDegree { get; set; }
        public virtual Document Document { get; set; }
    }
}
