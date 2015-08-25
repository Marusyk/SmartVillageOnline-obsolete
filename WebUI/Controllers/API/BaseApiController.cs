using Domain;
using Domain.Abstract;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class BaseApiController<T> : ApiController, IBaseApiInterface<T>  where T : BaseEntity
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();

        private string GenericTypeName
        {
            get { return typeof(T).Name; }
        }

        protected IRepository<T> repository;

        public BaseApiController()
        {
            repository = unitOfWork.EFRepository<T>();
        }

        public BaseApiController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        [EnableQuery]
        public virtual IQueryable<T> Get()
        {
            var entity = repository.Table;

            if (entity.Count() == 0 || entity == null) 
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
            return entity;
        }

        public virtual T GetById(int id)
        {
            var entity = repository.GetById(id);

            if (entity == null)
            {                
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No {0} with ID = {1}", GenericTypeName, id)),
                };
                throw new HttpResponseException(resp);
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
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, string.Format("Code: 500, Message: {0}", ex.Message));
            }

        }

        public virtual HttpResponseMessage Delete(int id)
        {
            T toDelete = repository.GetById(id);

            if (toDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format("No {0} with ID = {1}", GenericTypeName, id));
            }
            try
            {
                repository.Delete(toDelete);
                return Request.CreateResponse(HttpStatusCode.OK, toDelete.ID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, string.Format("Code: 500, Message: {0}", ex.Message));
            }
        }

        public virtual HttpResponseMessage Put([FromBody]T entity)
        {
            T oldEntity = repository.GetById(entity.ID);

            if (oldEntity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, string.Format("No {0} with ID = {1}", GenericTypeName, entity.ID));
            }
            try
            {
                oldEntity = entity;
                oldEntity.LastUpdDT = DateTime.Now;
                repository.Update(oldEntity);
                return Request.CreateResponse(HttpStatusCode.OK, oldEntity);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, string.Format("Code: 500, Message: {0}", ex.Message));
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
