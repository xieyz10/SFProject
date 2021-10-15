using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;
using Project1.Services;

namespace Project1.TasksController
{
    public class TasksController:Controller
    {
        private readonly ITasksServices _taskService;
        private readonly IEmployeeServices _employeeService;
        public TasksController(ITasksServices taskService, IEmployeeServices employeeService)
        {
            _taskService = taskService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int employeeId)
        {
            var task = await _taskService.GetTasks(employeeId);
            ViewBag.EmployeeId = employeeId;
            return View(task);
        }

        [HttpGet]
        public IActionResult Add(int EmployeeId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Tasks
            {
                EmployeeID = EmployeeId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tasks model)
        {
            if (ModelState.IsValid)
            {
                await _taskService.Add(model);
            }
            return RedirectToAction(nameof(Index), new { EmployeeID = model.EmployeeID });
        }

        public async Task<IActionResult> Return()

        {
            return RedirectToAction("Index", "Employee");

        }
    }
}
