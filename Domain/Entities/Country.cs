using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Country")]
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
}
