using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        [Required(ErrorMessage = "Please specify a city")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "Please specify a street")]
        public int StreetID { get; set; }

        public int PostCode { get; set; }

        public string BuildNr { get; set; }

        public string FlatNr { get; set; }
    }
}
