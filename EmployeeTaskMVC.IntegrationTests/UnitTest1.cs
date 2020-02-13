using EmployeeTaskMVC.Controllers;
using System;
using Xunit;

namespace EmployeeTaskMVC.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            appHost.SimulateBrowsingSession(browsingSession => {
                // Request the root URL
                RequestResult result = browsingSession.ProcessRequest("/");

                // You can make assertions about the ActionResult...
                var viewResult = (ViewResult)result.ActionExecutedContext.Result;
                Assert.AreEqual("Index", viewResult.ViewName);
                Assert.AreEqual("Welcome to ASP.NET MVC!", viewResult.ViewData["Message"]);

                // ... or you can make assertions about the rendered HTML
                Assert.IsTrue(result.ResponseText.Contains("<!DOCTYPE html"));
            });
        }
    }
}
