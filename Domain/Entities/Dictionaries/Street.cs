using Domain.Abstract;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Street : BaseDictionary
    {       
        [Required(ErrorMessage = "Please specify a type of street")]
        public int StreetTypeID { get; set; }
    }
}
