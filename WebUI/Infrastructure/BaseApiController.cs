﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using Domain;
using Domain.Abstract;

namespace WebUI.Infrastructure
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

        protected string GenericTypeName => typeof(T).Name;

        protected HttpResponseMessage ErrorMsg(HttpStatusCode statusCode, string errorMsg)
        {
            var error = new HttpError()
            {
                Message = $"code: {statusCode}",
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

        private Uri GetCreatedEntityLink(int id)
        {
            return new Uri(Url.Link("DefaultApi", new { id }));
        }

        #endregion

        #region GET
        [EnableQuery]
        public virtual HttpResponseMessage Get()
        {
            var entity = Repository.GetAll();

            if (entity != null && entity.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }

            var message = $"{GenericTypeName}: No content";
            return ErrorMsg(HttpStatusCode.NoContent, message);
        }

        [HttpGet]
        public virtual HttpResponseMessage GetFull(int id, string entities)
        {            
            var propertyList = "0".Equals(entities) ? GetJoinedPropertyList() : entities;
            var includeProperties = propertyList.Split(',');

            try
            {
                var entity = Repository.GetSingleIncluding(id, includeProperties);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }

            var message = $"No {GenericTypeName} with ID = {id}";
            return ErrorMsg(HttpStatusCode.NoContent, message);
        }

        [EnableQuery]
        public virtual HttpResponseMessage Get(int pageNo, int pageSize)
        {
            var localPageNo = NormalizePageNo(pageNo);
            var localPageSize = NormalizePageSize(pageSize);

            var paginatedEntities = Repository.Paginate(localPageNo, localPageSize, x => x.ID);

            if (!paginatedEntities.Any())
            {
                var message = $"{GenericTypeName}: No content";
                return ErrorMsg(HttpStatusCode.NoContent, message);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, paginatedEntities);
            response.Headers.Add("X-Paging-PageNo", localPageNo.ToString());
            response.Headers.Add("X-Paging-PageSize", localPageSize.ToString());
            response.Headers.Add("X-Paging-PageCount", paginatedEntities.TotalPageCount.ToString());
            response.Headers.Add("X-Paging-TotalRecordCount", paginatedEntities.TotalCount.ToString());
            return response;
        }

        public virtual HttpResponseMessage GetById(int id)
        {
            var entity = Repository.GetById(id);

            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }

            var message = $"No {GenericTypeName} with ID = {id}";
            return ErrorMsg(HttpStatusCode.NoContent, message);
        }

        #endregion

        #region POST
        public virtual HttpResponseMessage Post([FromBody]T entity)
        {           
            try
            { 
                Repository.Add(entity);
                var saveResult = Repository.Save();

                if (!saveResult)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var response = Request.CreateResponse(HttpStatusCode.Created, entity);
                response.Headers.Location = GetCreatedEntityLink(entity.ID);
                return response;
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
            var toDelete = Repository.GetById(id);

            if (toDelete == null)
            {
                return ErrorMsg(HttpStatusCode.NotFound, $"No {GenericTypeName} with ID = {id}");
            }
            try
            {
                Repository.Delete(toDelete);
                var saveResult = Repository.Save();
                var message = $"{GenericTypeName} with ID = {id} was " + (saveResult ? "deleted" : "not deleted");
                return ErrorMsg(HttpStatusCode.OK, message);
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region PUT
        public virtual HttpResponseMessage Put(int id, [FromBody]T entity)
        {
            var oldEntity = Repository.GetById(id);

            if (oldEntity == null)
            {
                return ErrorMsg(HttpStatusCode.NotFound, $"No {GenericTypeName} with ID = {id}");
            }
            try
            {
                entity.ID = id;
                Repository.Edit(entity);
                var saveResult = Repository.Save();

                return saveResult ? 
                    Request.CreateResponse(HttpStatusCode.OK, entity) : 
                    Request.CreateResponse(HttpStatusCode.NotModified, oldEntity);                
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion        
    }
}
