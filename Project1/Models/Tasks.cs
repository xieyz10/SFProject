using System;
namespace Project1.Models
{
    public class Tasks
    {
        public int EmployeeID { get; set; }
        public string TaskName { get; set; }
        public string StartTime { get; set; }
        public string DeadLine { get; set; }

        public Tasks() { }
        public Tasks(int EmployeeID, string TaskName, string StartTime, string DeadLine)
        {
            this.EmployeeID = EmployeeID;
            this.TaskName = TaskName;
            this.StartTime = StartTime;
            this.DeadLine = DeadLine;
        }
    }
}
