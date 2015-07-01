using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        [Required(ErrorMessage = "Please specify a name")]
        public string Name { get; set; }
    }
}
