using Domain.Abstract;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Domain.Entities.Dictionaries;

namespace Domain.Entities
{
    public class House : BaseEntity
    {
        public string HouseNr { get; set; }

        public string KadastrNr { get; set; }

        public string BuildNr { get; set; }

        public int AddressID { get; set; }

        public string PhoneNr { get; set; }

        public string PhoneCode { get; set; }

        public string FaxNr { get; set; }

        public int? Year { get; set; }

        public string Code { get; set; }

        //FK to Address
        public virtual Address Address { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<People> Peoples { get; set; }
    }
}
