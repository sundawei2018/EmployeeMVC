using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EmployeeTaskMVC.Controllers;
using EmployeeTaskMVC.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeeTaskMVC.Tests.Controllers
{
    [TestClass]
    public class EmployeesControllerTest
    {
        [TestMethod]
        public async Task IndexAsync()
        {
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "Jack", LastName = "Robinson", HiredDate = DateTime.Parse("2012-12-12")},
                new Employee { EmployeeId = 2, FirstName = "Lily", LastName = "White", HiredDate = DateTime.Parse("2016-10-12")},
            };
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(e => e.GetEmployees()).ReturnsAsync(employees);
            var controller = new EmployeesController(employeeRepository.Object);
            var result = await controller.Index() as ViewResult;
            var model = result.Model as List<Employee>;
            Assert.IsNotNull(result);
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public async Task DetailsAsync()
        {
            var employee = new Employee { EmployeeId = 1, FirstName = "Jack", LastName = "Robinson", HiredDate = DateTime.Parse("2012-12-12") };      
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(e => e.GetEmployee(It.IsAny<Int16>())).ReturnsAsync(employee);
            var controller = new EmployeesController(employeeRepository.Object);
            var result = await controller.Details(It.IsAny<Int16>()) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Model, employee);
        }
    }
}
