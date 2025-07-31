using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project8DayAndNight.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname{ get; set; }
        public string EmployeeSalary{ get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } // Navigation property

    }
}