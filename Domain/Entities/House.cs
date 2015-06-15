using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
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
        public int Year { get; set; }
        public string Code { get; set; }
        private DateTime LastUpdDT
        {
            get
            {
                return LastUpdDT;
            }
            set
            {
                value = DateTime.Now;
            }
        }
        public string LastUpdUS { get; set; }
    }
}
