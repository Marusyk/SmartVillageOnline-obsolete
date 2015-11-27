using Domain;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class BaseApiController<T> : ApiController, IBaseApiInterface<T>  where T : BaseEntity
    {
        public BaseApiController()
        {
            Repository = UnitOfWork.EFRepository<T>();
        }

        public BaseApiController(IRepository<T> repository)
        {
            Repository = repository;
        }

        #region Protected

        protected UnitOfWork UnitOfWork = new UnitOfWork();
        protected IRepository<T> Repository;

        protected string GenericTypeName
        {
            get { return typeof(T).Name; }
        }

        protected HttpResponseMessage ErrorMsg(HttpStatusCode statusCode, string errorMsg)
        {
            var error = new HttpError()
            {
                Message = string.Format("code: {0}", (int)statusCode),
                MessageDetail = errorMsg
            };            
            return Request.CreateResponse(statusCode, error);
        }

        protected override void Dispose(bool disposing)
        {
            UnitOfWork.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region Private
        private static int NormalizePageNo(int pageNo)
        {
            return pageNo > 0 ? pageNo : 1;
        }

        private static int NormalizePageSize(int pageSize)
        {
            return pageSize > 0 ? pageSize : 0;
        }

        private static string GetJoinedPropertyList()
        {
            IList<string> propertyNames = new List<string>();

            foreach (var prop in typeof(T).GetProperties().Where(p => p.GetGetMethod().IsVirtual))
            {
                if (prop.PropertyType.IsClass && !prop.PropertyType.FullName.StartsWith("System."))
                {
                    propertyNames.Add(prop.Name);
                }
            }
            return string.Join(",", propertyNames);
        }
        #endregion

        #region GET

        public virtual HttpResponseMessage Get()
        {
            var entity = Repository.GetAll();

            if (!entity.Any() || entity == null)
            {
                var message = string.Format("{0}: No content", GenericTypeName);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public virtual HttpResponseMessage GetFull(int id, string entities)
        {            
            var propertyList = "0".Equals(entities) ? GetJoinedPropertyList() : entities;
            var includeProperties = propertyList.Split(',');
            T entity;

            try
            {
                entity = Repository.GetSingleIncluding(id, includeProperties);
                
                if (entity == null)
                {
                    var message = string.Format("No {0} with ID = {1}", GenericTypeName, id);
                    return ErrorMsg(HttpStatusCode.NotFound, message);
                }
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }            

            return Request.CreateResponse(HttpStatusCode.OK, entity);                
        }

        public virtual HttpResponseMessage Get(int pageNo, int pageSize)
        {
            var localPageNo = NormalizePageNo(pageNo);
            var localPageSize = NormalizePageSize(pageSize);

            var paginatedEntities = Repository.Paginate(localPageNo, localPageSize, x => x.ID);

            var total = paginatedEntities.TotalCount;
            var pageCount = paginatedEntities.TotalPageCount;

            if (!paginatedEntities.Any())
            {
                var message = string.Format("{0}: No content", GenericTypeName);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, paginatedEntities);
            response.Headers.Add("X-Paging-PageNo", localPageNo.ToString());
            response.Headers.Add("X-Paging-PageSize", localPageSize.ToString());
            response.Headers.Add("X-Paging-PageCount", pageCount.ToString());
            response.Headers.Add("X-Paging-TotalRecordCount", total.ToString());
            return response;
        }

        public virtual HttpResponseMessage GetById(int id)
        {
            var entity = Repository.GetById(id);

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
                Repository.Add(entity);
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
            var toDelete = Repository.GetById(id);

            if (toDelete == null)
            {
                message = string.Format("No {0} with ID = {1}", GenericTypeName, id);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            try
            {
                Repository.Delete(toDelete);
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
            var oldEntity = Repository.GetById(entity.ID);

            if (oldEntity == null)
            {
                return ErrorMsg(HttpStatusCode.NotFound, string.Format("No {0} with ID = {1}", GenericTypeName, entity.ID));
            }
            try
            {
                oldEntity = entity;
                oldEntity.LastUpdDT = DateTime.Now;
                Repository.Edit(oldEntity);
                return Request.CreateResponse(HttpStatusCode.OK, oldEntity);
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion        
    }
}
