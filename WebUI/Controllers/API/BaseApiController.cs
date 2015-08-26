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

        #region Private
        private string GenericTypeName
        {
            get { return typeof(T).Name; }
        }

        private HttpResponseMessage ErrorMsg(HttpStatusCode statusCode, string errorMsg)
        {
            HttpError error = new HttpError()
            {
                Message = string.Format("code: {0}", (int)statusCode),
                MessageDetail = errorMsg
            };            
            return Request.CreateResponse(statusCode, error);
        }
        #endregion
       
        #region GET

        [EnableQuery]
        public virtual IQueryable<T> Get()
        {
            var entity = repository.Table;

            if (entity.Count() == 0 || entity == null) 
            {
                var message = string.Format("{0}: No content", GenericTypeName);
                throw new HttpResponseException(ErrorMsg(HttpStatusCode.NotFound, message));
            }
            return entity;
        }

        public virtual T GetById(int id)
        {
            var entity = repository.GetById(id);

            if (entity == null)
            {                
                var message = string.Format("No {0} with ID = {1}", GenericTypeName, id);
                throw new HttpResponseException(ErrorMsg(HttpStatusCode.NotFound, message));
            }
            return entity;
        }
        #endregion

        #region POST
        public virtual HttpResponseMessage Post([FromBody]T entity)
        {           
            try
            { 
                repository.Insert(entity);
                return Request.CreateResponse(HttpStatusCode.Created, entity);             
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        #endregion

        #region DELETE
        public virtual HttpResponseMessage Delete(int id)
        {
            string message;
            T toDelete = repository.GetById(id);

            if (toDelete == null)
            {
                message = string.Format("No {0} with ID = {1}", GenericTypeName, id);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            try
            {
                repository.Delete(toDelete);
                message = string.Format("{0} with ID = {1} was deleted", GenericTypeName, id);
                return ErrorMsg(HttpStatusCode.OK, message);
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region PUT
        public virtual HttpResponseMessage Put([FromBody]T entity)
        {
            T oldEntity = repository.GetById(entity.ID);

            if (oldEntity == null)
            {
                return ErrorMsg(HttpStatusCode.NotFound, string.Format("No {0} with ID = {1}", GenericTypeName, entity.ID));
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
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
