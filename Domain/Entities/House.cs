using Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class House : BaseEntity
    {
        [Required(ErrorMessage = "Please specify a number of house")]
        public string HouseNr { get; set; }
        public string KadastrNr { get; set; }
        [Required(ErrorMessage = "Please specify a number of build")]
        public string BuildNr { get; set; }
        [Required(ErrorMessage = "Please specify an address of house")]
        public int AddressID { get; set; }
        public string PhoneNr { get; set; }
        public string PhoneCode { get; set; }
        public string FaxNr { get; set; }
        public int? Year { get; set; }
        public string Code { get; set; }
    }
}
