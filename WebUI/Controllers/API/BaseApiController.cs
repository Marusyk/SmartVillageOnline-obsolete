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

            if (entity == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent("There is no content")
                };
                throw new HttpResponseException(resp);
            }
            return entity;
        }

        public virtual T GetById(int id)
        {
            string entityName = typeof(T).Name;
            var entity = repository.GetById(id);

            if (entity == null)
            {                
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No {0} with ID = {1}", entityName, id)),
                    ReasonPhrase = string.Format("{0} Not Found", entityName)
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
                HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.Created, entity);
                //msg.Headers.Location = new Uri(Request.RequestUri + "/" + (repository.Table.Count() - 1));
                return msg;                
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format("code: 500, message: {1}", ex.HelpLink, ex.Message)),
                   // ReasonPhrase = string.Format("{0} Not Found", entityName)
                };
                return Request.CreateResponse(resp);
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
                return Request.CreateResponse(HttpStatusCode.OK, toDelete.ID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
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
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
