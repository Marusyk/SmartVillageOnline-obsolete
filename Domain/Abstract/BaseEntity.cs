using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime LastUpDt { get; set; }
        public string LastUpUs { get; set; }
    }
}
