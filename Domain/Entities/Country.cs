using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
}
