using Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        [Required(ErrorMessage = "Please specify a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please specify a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please specify a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please specify a date of birthday")]
        public DateTime DateBith { get; set; }

        [Required(ErrorMessage = "Please specify a sex")]
        public bool Sex { get; set; }

        public bool IsResident { get; set; }

        public int AddressBithId { get; set; }

        public int AddressLiveId { get; set; }

        public int NationalityId { get; set; }

        [MaxLength(10)]
        public string IdentificationCode { get; set; }

        [MaxLength(2)]
        public string PassSeria { get; set; }

        public int PassNr { get; set; }

        public DateTime PassDate { get; set; }

        public int PassAuthorityId { get; set; }

        public int FamilyStatusId { get; set; }

        public int CitizenshipId { get; set; }

        [Required(ErrorMessage = "Please specify a catalog")]
        public int CatalogId { get; set; }

        public bool IsSojourn { get; set; }

        public byte Photo { get; set; }

        public string PadFirstName { get; set; }

        public string PadName { get; set; }

        public string PadLastName { get; set; }

        public string DatFirstName { get; set; }

        public string DatName { get; set; }

        public string DatLastName { get; set; }
    }
}
