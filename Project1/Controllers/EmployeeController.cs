using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;
using Project1.Services;


namespace Project1.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeeController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Employee Index";
            var employee = await _employeeService.GetAll();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int employeeId)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Delete(employeeId);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int employeeId, Employee model)
        {
            ViewBag.Title = "Update Employee";
            var employees = _employeeService.GetAllEmployees();
            var em = employees.FirstOrDefault(e => e.Id == employeeId);
            return View(em);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Update(model);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
