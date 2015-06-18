using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstract;

namespace Domain.Entities
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        public string Name { get; set; }
    }
}
