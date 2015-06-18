using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstract;

namespace Domain.Entities
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        //public int CountryID { get; set; }
        public string Name { get; set; }
    }
}
