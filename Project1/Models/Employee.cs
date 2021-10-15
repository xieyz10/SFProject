using System;
using System.Collections;
using Project1.Models;
using System.Collections.Generic;

namespace Project1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HiredDate { get; set; }
        public List<Tasks> Task { get; set; }

        public Employee() { }
        public Employee(int id, string FirstName, string LastName, string HiredDate)
        {
            this.Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.HiredDate = HiredDate;
            this.Task = new List<Tasks>();
        }
    }
}
