using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Project1.Services
{
    public class EmployeeServices:IEmployeeServices
    {
        private readonly List<Employee> _employees = new List<Employee>(); 
        public EmployeeServices()
        {
            Employee em1 = new Employee(1,"Jim","Ryan", "09/18/2019");
            Tasks task1 = new Tasks(1, "task1","10/29/2019","11/23/2020");
            Tasks task2 = new Tasks(1, "task2", "10/29/2020", "11/23/2020");
            Tasks task3 = new Tasks(1, "task3", "1129/2020", "11/23/2020");
            em1.Task.Add(task1);
            em1.Task.Add(task2);
            em1.Task.Add(task3);
            _employees.Add(em1);

            Employee em2 = new Employee(2, "Mark", "Cerny", "11/19/2020");
            Tasks task4 = new Tasks(2, "task4", "09/26/2019", "10/23/2020");
            Tasks task5 = new Tasks(2, "task5", "08/29/2019", "10/23/2020");
            Tasks task6 = new Tasks(2, "task6", "10/26/2019", "10/23/2020");
            em2.Task.Add(task4);
            em2.Task.Add(task5);
            em2.Task.Add(task6);
            _employees.Add(em2);

            Employee em3 = new Employee(3, "Tom", "Cerny", "07/05/2018");
            Tasks task7 = new Tasks(3, "task7", "10/26/2019", "10/23/2020");
            Tasks task8 = new Tasks(3, "task8", "11/26/2019", "10/23/2020");
            Tasks task9 = new Tasks(3, "task9", "12/26/2019", "10/23/2020");
            em3.Task.Add(task7);
            em3.Task.Add(task8);
            em3.Task.Add(task9);
            _employees.Add(em3);

            Employee em4 = new Employee(4, "Tom", "Cerny", "08/19/2021");
            Tasks task10 = new Tasks(4, "task10", "09/26/2019", "10/23/2020");
            Tasks task11 = new Tasks(4, "task11", "08/26/2018", "10/23/2020");
            Tasks task12 = new Tasks(4, "task12", "07/26/2017", "10/23/2020");
            em4.Task.Add(task10);
            em4.Task.Add(task11);
            em4.Task.Add(task12);
            _employees.Add(em4);
        }

        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            employee.Task = new List<Tasks>();
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task Delete(int employeeId)
        {
            var em = _employees.FirstOrDefault(e => e.Id == employeeId);
            _employees.Remove(em);
            return Task.CompletedTask;
        }

        public Task Update(Employee model)
        {
            var em = _employees.FirstOrDefault(e => e.Id == model.Id);
            em.FirstName = model.FirstName;
            em.LastName = model.LastName;
            em.HiredDate = model.HiredDate;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            return Task.Run(() => _employees.AsEnumerable());
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
    }
}
