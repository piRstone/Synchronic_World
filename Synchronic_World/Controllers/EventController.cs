using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synchronic_World.Models;
using System.Data;

namespace Synchronic_World.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        public ActionResult Event()
        {
            if (Session["LoggedUserId"] != null)
            {
                synchronicDBEntities entity = new synchronicDBEntities();
                return View(entity.EventSet);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult createEvent()
        {
            if (Session["LoggedUserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createEvent(Event e)
        {
            if (ModelState.IsValid)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    e.status = "0";
                    entity.EventSet.Add(e);
                    entity.SaveChanges();
                    ModelState.Clear();
                    e = null;
                    return RedirectToAction("Event", "Event");
                }
            }
            return View(e);
        }

        public ActionResult editEvent(int id)
        {
            if ((Session["LoggedUserRole"] as String) == "1")
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    Event e = entity.EventSet.Find(id);
                    return View(e);
                }
            }
            else
            {
                ViewBag.Error = "You must be admin to do this action !";
                return RedirectToAction("Event", "Event", new { ViewBag.Error });
            }
        }

        [HttpPost]
        public ActionResult editEvent(Event e)
        {
            if (ModelState.IsValid)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    entity.EventSet.Attach(e);
                    entity.Entry(e).State = EntityState.Modified;
                    entity.SaveChanges();
                    ModelState.Clear();
                    e = null;
                    return RedirectToAction("Event", "Event");
                }
            }
            return View(e);
        }

        public ActionResult deleteEvent(int id)
        {
            using (synchronicDBEntities entity = new synchronicDBEntities())
            {
                Event e = new Event();
                e = entity.EventSet.Find(id);
                entity.EventSet.Remove(e);
                entity.SaveChanges();
                e = null;
                return RedirectToAction("Event", "Event");
            }
        }

    }
}
