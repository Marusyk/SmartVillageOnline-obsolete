using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Dictionaries
{
    public class District : BaseDictionary
    {
        [Required(ErrorMessage = "Please specify a region")]
        public int RegionID { get; set; }
    }
}
