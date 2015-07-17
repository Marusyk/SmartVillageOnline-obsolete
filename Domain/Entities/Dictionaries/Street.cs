using Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Street : BaseDictionary
    {       
        [Required(ErrorMessage = "Please specify a type of street")]        
        public int StreetTypeID { get; set; }

        // create foreign key using Lazy Load (virtual)
        public virtual StreetType StreetType { get; set; }
    }
}
