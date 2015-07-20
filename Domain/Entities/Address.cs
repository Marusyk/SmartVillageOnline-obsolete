using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public int CityID { get; set; }

        public int? StreetID { get; set; }

        public int? PostCode { get; set; }

        public string BuildNr { get; set; }

        public string FlatNr { get; set; }
    }
}
