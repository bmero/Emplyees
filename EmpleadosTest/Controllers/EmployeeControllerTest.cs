using System;
using System.Collections.Generic;
using System.Text;
using Empleados.Model;
using Empleados.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EmpleadosData;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosTest.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public async Task GetEmployees_returnValue()
        {
            //Arrange
            EmployeeViewModel a = new EmployeeViewModel
            {
                ID = 1,
                Name = "prue",
                SalaryAnual = 100000
            };
            List<EmployeeViewModel> expected = new List<EmployeeViewModel>();
            expected.Add(a);
            Mock<EmployeesDbContext> emp = new Mock<EmployeesDbContext>();
            var controller = new EmployeeController(emp.Object);

            //Act
            var actual = await controller.GetEmployees();

            //Assert
            Assert.IsInstanceOfType(expected, typeof(List<EmployeeViewModel>));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetEmployees_returnOnlyValue()
        {           
            //Arrange
            EmployeeViewModel expected = new EmployeeViewModel
            {
                ID = 1,
                Name = "prue",
                SalaryAnual = 100000
            };
            int b = 1;

            Mock<EmployeesDbContext> emp = new Mock<EmployeesDbContext>();
            var controller = new EmployeeController(emp.Object);

            //Act
            var actual = await controller.GetEmployee(b);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(EmployeeViewModel));
            Assert.AreEqual(expected, actual);
        }
    }
}
