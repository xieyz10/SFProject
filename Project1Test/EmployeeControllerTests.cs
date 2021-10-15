using System;
using System.Threading.Tasks;
using Xunit;
using Project1.Models;
using Project1.Controllers;
using Project1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project1Test
{
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeTest;
        private readonly IEmployeeServices _employeeSercice;

        public EmployeeControllerTests()
        {
            _employeeSercice = new EmployeeServices();
            this._employeeTest = new EmployeeController(_employeeSercice);
        }

        [Fact]
        public async Task TestAdd()
        {
            Employee em = new Employee(5, "Tom", "Cerny", "07/05/2018");
            var ret = await _employeeTest.Add(em);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(ret);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task TestDelete()
        {
            var ret = await _employeeTest.Delete(1);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(ret);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task TestUpdate()
        {
            Employee em = new Employee(1, "Nicole", "Cerny", "07/05/2018");
            var ret = await _employeeTest.Update(em);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(ret);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    }
}
