using System;

namespace Domain.Abstract
{
    public interface IEntity
    {
        int ID { get; set; }

        DateTime LastUpdDT { get; set; }

        string LastUpdUS { get; set; }
    }
}
