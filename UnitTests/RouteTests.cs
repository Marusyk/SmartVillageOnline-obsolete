using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using Moq;
using System.Reflection;
using System.Web.Routing;
using WebUI;

namespace UnitTests
{
    [TestClass]
    public class RouteTests
    {
#region private
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // створити mock-запит
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // створити mock-response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns<string>(s => s);

            // створити mock-context використовуючи request i response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller, string action, 
            object routeProperties = null, string httpMethod = "GET")
        {
            //Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase
                .Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller)
                && valCompare(routeResult.Values["action"], action);
            if (propertySet != null)
            {
                PropertyInfo[] propertyInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propertyInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], 
                        pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteFail(string url)
        {
            //Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            //Assert
            Assert.IsTrue(result == null || result.Route == null);
        }

        #endregion

        [TestMethod]
        public void TestIncomingRoutes()
        {
            TestRouteMatch("~/Home/Index", "Home", "Index");
            TestRouteMatch("~/One/Two", "One", "Two");
            TestRouteFail("~/Home/Index/Segment1/Segment2");
        }
    }
}
