using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project8DayAndNight.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentIName{ get; set; }
        public List<Employee> Employees { get; set; }
    }
}