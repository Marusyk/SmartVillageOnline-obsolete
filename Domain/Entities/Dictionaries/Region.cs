using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Dictionaries
{
    public class Region : BaseDictionary
    {
        [Required(ErrorMessage = "Please specify a country")]
        public int CountryID { get; set; }
    }
}
