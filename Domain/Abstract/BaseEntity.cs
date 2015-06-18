using System;

namespace Domain.Abstract
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            LastUpdUS = "SV";
            LastUpdDT = DateTime.Now;
        }

        public int ID { get; set; }

        //[System.ComponentModel.DefaultValue()]
        public DateTime LastUpdDT { get; set; }
        
        public string LastUpdUS { get; set; }
    }
}
