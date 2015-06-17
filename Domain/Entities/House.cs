using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("House")]
    public class House
    {
        public int HouseID { get; set; }
        public string HouseNr { get; set; }
        public string KadastrNr { get; set; }
        public string BuildNr { get; set; }
        public int AddressID { get; set; }
        public string PhoneNr { get; set; }
        public string PhoneCode { get; set; }
        public string FaxNr { get; set; }
        public Nullable<int> Year { get; set; }
        public string Code { get; set; }
        public System.DateTime LastUpdDT { get; set; }
        public string LastUpdUS { get; set; }
    }
}
