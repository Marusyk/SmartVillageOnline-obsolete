﻿using Domain.Entities.Dictionaries;
using Domain.Abstract;


namespace WebUI.Controllers.API
{
    public class InstitutionController : BaseApiController<Institution>
    {
        public InstitutionController()
            : base()
        {
        }

        public InstitutionController(IRepository<Institution> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}