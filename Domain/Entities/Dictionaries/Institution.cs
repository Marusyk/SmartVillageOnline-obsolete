using Domain.Abstract;

namespace Domain.Entities.Dictionaries
{
    public class Institution : BaseDictionary
    {
        public int CityID { get; set; }

        //FK
        public virtual City City { get; set; }
    }
}
