using Domain;
using Domain.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.OData;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class BaseApiController<T> : ApiController/*, IBaseApiInterface<T>*/  where T : BaseEntity
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

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region Private
        private int NormalizePageNo(int pageNo)
        {
            return pageNo > 0 ? pageNo - 1 : 0;
        }

        private int NormalizePageSize(int pageSize)
        {
            return pageSize > 0 ? pageSize : 0;
        }

        private int CalculatePageCount(int total, int pageSize)
        {
            return total > 0 ? (int)Math.Ceiling(total / (double)pageSize) : 0;
        }

        private string GetJoinedPropertyList()
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

        [EnableQuery]
        public virtual HttpResponseMessage Get()
        {
            var entity = repository.GetAll();

            if (entity == null || !entity.Any())
            {
                var message = string.Format("{0}: No content", GenericTypeName);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public virtual HttpResponseMessage GetFull(int id, string entities)
        {            
            string propertyList = string.Empty;

            if ("0".Equals(entities))
            {
                propertyList = GetJoinedPropertyList();
            }
            else
            {
                propertyList = entities;
            }
                
            string entityName = typeof(T).Name;
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            var response = Request.CreateResponse(HttpStatusCode.Found);

            StringBuilder sb = new StringBuilder(1024);
            sb.Append(baseUrl);
            sb.Append("/api/");
            sb.Append(entityName);
            sb.Append("/");
            sb.Append(id);
            sb.Append("?$expand=");
            sb.Append(propertyList);

            response.Headers.Location = new Uri(sb.ToString());
            return response;
        }

        [EnableQuery]
        public virtual HttpResponseMessage Get(int pageNo, int pageSize)
        {
            /*pageNo = NormalizePageNo(pageNo);
            pageSize = NormalizePageSize(pageSize);

            int total = repository.Table.Count();
            int pageCount = CalculatePageCount(total, pageSize);

            var entity = repository.Table
                .OrderBy(c => c.ID)
                .Skip(pageNo * pageSize)
                .Take(pageSize);

            if (entity == null || !entity.Any())
            {
                var message = string.Format("{0}: No content", GenericTypeName);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, entity);
            response.Headers.Add("X-Paging-PageNo", (pageNo + 1).ToString());
            response.Headers.Add("X-Paging-PageSize", pageSize.ToString());
            response.Headers.Add("X-Paging-PageCount", pageCount.ToString());
            response.Headers.Add("X-Paging-TotalRecordCount", total.ToString());
            */
            return null;// response;
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

            return Request.CreateResponse(HttpStatusCode.OK, entity);// SingleResult.Create(repository.Table.Where(t => t.ID == id)));
        }

        #endregion

        #region POST
        public virtual HttpResponseMessage Post([FromBody]T entity)
        {           
            try
            { 
                repository.Add(entity);
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
                repository.Edit(oldEntity);
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
