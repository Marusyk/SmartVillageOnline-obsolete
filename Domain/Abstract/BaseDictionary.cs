using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Abstract
{
    public abstract class BaseDictionary : BaseEntity
    {
        [Required(ErrorMessage = "Please specify a name")]
        public string Name { get; set; }
    }
}
