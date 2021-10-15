using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Project1.Services
{
    public interface IEmployeeServices
    {
        Task Add(Employee employee);
        Task Delete(int employeeId);
        Task Update(Employee employee);
        Task<IEnumerable<Employee>> GetAll();
        List<Employee> GetAllEmployees();
    }
}
