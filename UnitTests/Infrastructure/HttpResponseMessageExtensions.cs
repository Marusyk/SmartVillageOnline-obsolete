using Domain.Abstract;
using System.Linq;
using System.Net.Http;

namespace UnitTests.Infrastructure
{
    public static class HttpResponseMessageExtensions
    {
        public static IQueryable<T> ContentToQueryable<T>(this HttpResponseMessage response) where T : BaseEntity
        {
            var objContent = response.Content as ObjectContent;
            return objContent.Value as IQueryable<T>;
        }

        public static T ContentToEntity<T>(this HttpResponseMessage response) where T : BaseEntity
        {
            var objContent = response.Content as ObjectContent;
            return objContent.Value as T;
        }
    }
}
