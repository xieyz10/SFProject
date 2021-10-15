using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Project1.Services
{
    public class TasksServices:ITasksServices
    {
        private readonly IEmployeeServices _employeeService;
        public TasksServices(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }
      
        public Task<IEnumerable<Tasks>> GetTasks(int employeeId)
        {
            var employees = _employeeService.GetAllEmployees();
            var em = employees.FirstOrDefault(e => e.Id == employeeId);
            return Task.Run(() => em.Task.AsEnumerable());
        }

        public Task Add(Tasks task)
        {
            var employees = _employeeService.GetAllEmployees();
            var em = employees.FirstOrDefault(e => e.Id == task.EmployeeID);
            Tasks newtask = new Tasks(task.EmployeeID,task.TaskName,task.StartTime,task.DeadLine);
            em.Task.Add(newtask);
            return Task.CompletedTask;
        }
    }
}
