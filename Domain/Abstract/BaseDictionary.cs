using System.ComponentModel.DataAnnotations;

namespace Domain.Abstract
{
    public abstract class BaseDictionary : BaseEntity
    {
        [Required(ErrorMessage = "Please specify a name")]
        public string Name { get; set; }
    }
}
