using System;
using System.Threading.Tasks;
using Xunit;
using Project1.Models;
using Project1.Controllers;
using Project1.Services;
using Microsoft.AspNetCore.Mvc;
using Project1.TasksController;

namespace Project1Test
{
    public class TasksControllerTests
    {
        private TasksController _tasksController;
        private readonly ITasksServices _tasksServices;
        private readonly IEmployeeServices _employeeServices;
        public TasksControllerTests()
        {
            _employeeServices = new EmployeeServices();
            _tasksServices = new TasksServices(_employeeServices);
            _tasksController = new TasksController(_tasksServices, _employeeServices);
        }

        [Fact]
        public async Task TestAdd()
        {
            Tasks task = new Tasks(1,"TestTask","10/15/2019","10/20/2019");
            var ret = await _tasksController.Add(task);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(ret);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    }
}
