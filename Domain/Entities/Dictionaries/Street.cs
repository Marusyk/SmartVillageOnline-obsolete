using Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Street : BaseDictionary
    {       
        [Required(ErrorMessage = "Please specify a type of street")]        
        public int StreetTypeID { get; set; }

        [ForeignKey("StreetTypeID")]
        public StreetType StreetType { get; set; }
    }
}
