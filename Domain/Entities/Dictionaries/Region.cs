using Domain.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Dictionaries
{
    public class Region : BaseDictionary
    {
        public int CountryID { get; set; }

        // FK to Country
        public virtual Country Countries { get; set; }
        public virtual ICollection<District> Districts { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
