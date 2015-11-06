﻿using Domain.Abstract;
using Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Document : BaseDictionary
    {
        public Document()
        {
            Educations = new HashSet<Education>();
            PersonDocuments = new HashSet<PersonDocuments>();
        }

        public int? DocumentTypeID { get; set; }

        public int? PassAuthorityID { get; set; }

        public string Number { get; set; }

        public string Code { get; set; }

        public bool State { get; set; }

        public DateTime DateReg { get; set; }

        //FK
        public virtual DocumentType DocumentType { get; set; }
        public virtual PassAuthority PassAuthority { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<PersonDocuments> PersonDocuments { get; set; }
    }
}
