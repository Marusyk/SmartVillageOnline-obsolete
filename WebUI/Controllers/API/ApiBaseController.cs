using Domain;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public abstract class ApiBaseController<T> : ApiController where T : BaseEntity
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();

        protected IRepository<T> repository;

        public ApiBaseController()
        {
            repository = unitOfWork.EFRepository<T>();
        }

        public ApiBaseController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual IEnumerable<T> Get()
        {
            return repository.Table.ToList();
        }

        public virtual T GetById(int id)
        {
            var entity = repository.GetById(id);
            if (entity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return entity;
        }

        public virtual HttpResponseMessage Post([FromBody]T entity)
        {
            try
            {
                repository.Insert(entity);
                return Request.CreateResponse(HttpStatusCode.Created, entity);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        public virtual HttpResponseMessage Delete(int id)
        {
            T toDelete = repository.GetById(id);

            if (toDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                repository.Delete(toDelete);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public virtual HttpResponseMessage Put([FromBody]T entity)
        {
            T oldEntity = repository.GetById(entity.ID);

            if (oldEntity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                oldEntity = entity;
                oldEntity.LastUpdDT = DateTime.Now;
                repository.Update(oldEntity);
                return Request.CreateResponse(HttpStatusCode.OK, oldEntity);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
