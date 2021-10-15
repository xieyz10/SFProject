using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Project1.Services
{
    public interface ITasksServices
    {
        Task<IEnumerable<Tasks>> GetTasks(int employeeId);
        Task Add(Tasks task);
    }
}
