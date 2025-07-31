using Project8DayAndNight.Context;
using Project8DayAndNight.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project8DayAndNight.Controllers
{
    public class CalendarController : Controller
    {
        private ProjectContext db = new ProjectContext();
        // Kategorileri getir (JSON)
        public JsonResult GetCategories()
        {
            var categories = db.Categories.Select(x => x.Name).ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        // Etkinlikleri getir (JSON)
        public JsonResult GetEvents()
        {
            var events = db.Events
                .ToList() // Önce veriyi çek
                .Select(e => new
                {
                    id = e.EventId,
                    title = e.Title,
                    color = e.Color,
                    category = e.Category.Name,
                    start = e.StartDate.ToString("yyyy-MM-dd"),
                    end = e.EndDate.ToString("yyyy-MM-dd")
                }).ToList();
            return Json(events, JsonRequestBehavior.AllowGet);
        }

        // Etkinlik ekle
        [HttpPost]
        public JsonResult AddEvent(string title, string color, string category, string start, string end)
        {
            var cat = db.Categories.FirstOrDefault(c => c.Name == category);
            if (cat == null)
                return Json(new { success = false, message = "Kategori bulunamadı" });

            var ev = new Event
            {
                Title = title,
                Color = color,
                CategoryId = cat.CategoryId,
                StartDate = DateTime.Parse(start),
                EndDate = DateTime.Parse(end)
            };
            db.Events.Add(ev);
            db.SaveChanges();
            return Json(new { success = true, id = ev.CategoryId });
        }

        // Etkinlik sil
        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var ev = db.Events.Find(id);
            if (ev == null)
                return Json(new { success = false, message = "Etkinlik bulunamadı" });
            db.Events.Remove(ev);
            db.SaveChanges();
            return Json(new { success = true });
        }

        // Etkinlik güncelle
        [HttpPost]
        public JsonResult UpdateEvent(int id, string title, string color, string category)
        {
            var ev = db.Events.Find(id);
            if (ev == null)
                return Json(new { success = false, message = "Etkinlik bulunamadı" });
            var cat = db.Categories.FirstOrDefault(c => c.Name == category);
            if (cat == null)
                return Json(new { success = false, message = "Kategori bulunamadı" });

            ev.Title = title;
            ev.Color = color;
            ev.CategoryId = cat.CategoryId;
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
