using Domain.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Abstract
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            LastUpdUS = "SV";
            LastUpdDT = DateTime.Now;
        }

        public IdType ID { get; set; }

        [Required(ErrorMessage = "Please specify a date of the last update")]
        public DateTime LastUpdDT { get; set; }

        [Required(ErrorMessage = "Please specify a user's name of the last update")]
        public string LastUpdUS { get; set; }
    }
}
