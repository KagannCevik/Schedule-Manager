using Project8DayAndNight.Context;
using Project8DayAndNight.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project8DayAndNight.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Category
        ProjectContext context = new ProjectContext();
        public ActionResult DepartmentList()
        {
            var values = context.Departments.ToList();
            return View(values);
        }
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Entities.Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        public ActionResult DeleteDepartment(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        public ActionResult UpdateDepartment(int id)
        {
            var department = context.Departments.Find(id);
            return View(department);
        }
        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {

            //EntityState
            var values = context.Departments.Find(department.DepartmentId);
            values.DepartmentIName = department.DepartmentIName;
            context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
    }
}