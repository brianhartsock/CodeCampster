using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web;
using Moq;
using CodeCampster.Views;
using CodeCampster;

namespace CodeCampster.Tests.Views
{
    //Giving up, this is way too hard to write tests
    [TestFixture]
    public class HtmlMasterMenuTests
    {
        [SetUp]
        public void Setup()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void checking_default_route()
        {
            var httpRequest = new Mock<HttpRequestBase>();
            httpRequest.Setup(r => r.PathInfo).Returns("");
            httpRequest.SetupGet(r => r.AppRelativeCurrentExecutionFilePath).Returns("~/foo/bar");
            
            var httpContext = new Mock<HttpContextBase>();
            httpContext.SetupAllProperties();
            httpContext.SetupGet(c => c.Request).Returns(httpRequest.Object);

            var viewContext = new ViewContext()
            {
                RouteData = RouteTable.Routes.GetRouteData(httpContext.Object)
            };

            var helper = new HtmlHelper(viewContext, new ViewPage());
            Assert.That(helper.MasterMenu("asdf", "asdf", "asdf"), Is.EqualTo(""));

        }
    }
}
