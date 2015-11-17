﻿using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities.Dictionaries
{
    public class Institution : BaseDictionary
    {
        public Institution()
        {
            Educations = new HashSet<Education>();
        }
        public int CityID { get; set; }

        //FK
        public virtual City City { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }
}
