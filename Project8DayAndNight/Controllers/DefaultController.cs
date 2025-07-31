using Project8DayAndNight.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Project8DayAndNight.Controllers
{
    public class DefaultController : Controller
    {
        ProjectContext db = new ProjectContext();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            
            var events = db.Events
                .Include(e => e.Category)
                .OrderBy(e => e.StartDate)
                .Take(1000)
                .ToList();

            return View(events);
        }

      
        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            var ev = db.Events.Find(id);
            if (ev != null)
            {
                db.Events.Remove(ev);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}