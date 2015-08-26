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
        public BaseApiController()
        {
            repository = unitOfWork.EFRepository<T>();
        }

        public BaseApiController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        #region Protected

        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected IRepository<T> repository;

        protected string GenericTypeName
        {
            get { return typeof(T).Name; }
        }

        protected HttpResponseMessage ErrorMsg(HttpStatusCode statusCode, string errorMsg)
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
        public virtual HttpResponseMessage Get()
        {
            var entity = repository.Table;

            if (entity.Count() == 0 || entity == null)
            {
                var message = string.Format("{0}: No content", GenericTypeName);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [EnableQuery]
        public virtual HttpResponseMessage Get(int pageNo, int pageSize)
        {
            pageNo = pageNo > 0 ? pageNo - 1 : 0;
            pageSize = pageSize > 0 ? pageSize : 0;

            int total = repository.Table.Count();
            int pageCount = total > 0 ? (int)Math.Ceiling(total / (double)pageSize) : 0;

            var entity = repository.Table.OrderBy(c => c.ID).Skip(pageNo * pageSize).Take(pageSize);

            if (entity.Count() == 0 || entity == null)
            {
                var message = string.Format("{0}: No content", GenericTypeName);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, entity);
            response.Headers.Add("X-Paging-PageNo", (pageNo + 1).ToString());
            response.Headers.Add("X-Paging-PageSize", pageSize.ToString());
            response.Headers.Add("X-Paging-PageCount", pageCount.ToString());
            response.Headers.Add("X-Paging-TotalRecordCount", total.ToString());

            return response;
        }

        [EnableQuery]
        public virtual HttpResponseMessage GetById(int id)
        {
            var entity = repository.GetById(id);

            if (entity == null)
            {                
                var message = string.Format("No {0} with ID = {1}", GenericTypeName, id);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, entity);
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
