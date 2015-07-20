using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Catalog : BaseEntity
    {
        public int? ParentId { get; set; }

        public string Name { get; set; }

        public int? ModuleId { get; set; }
    }
}
