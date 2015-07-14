using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Dictionaries
{
    public class City : BaseDictionary
    {
        [Required(ErrorMessage = "Please specify a type of city")]
        public int CityTypeID { get; set; }

        public int DistrictID { get; set; }

        public int RegionID { get; set; }
    }
}
