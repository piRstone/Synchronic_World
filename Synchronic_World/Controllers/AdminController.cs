using Synchronic_World.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Panel()
        {
            if (Session["LoggedUserRole"] as String == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Event", "Event");
            }
        }

        public ActionResult manageUsers()
        {
            if (Session["LoggedUserRole"] as String == "1")
            {
                synchronicDBEntities entity = new synchronicDBEntities();
                return View(entity.UserSet);
            }
            else
            {
                return RedirectToAction("Panel", "Admin");
            }
        }

        public ActionResult manageEvents()
        {
            if (Session["LoggedUserRole"] as String == "1")
            {
                synchronicDBEntities entity = new synchronicDBEntities();
                return View(entity.EventSet);
            }
            else
            {
                return RedirectToAction("Panel", "Admin");
            }
        }

        public ActionResult openEvent(int id)
        {
            using (synchronicDBEntities entity = new synchronicDBEntities())
            {
                Event e = entity.EventSet.Find(id);
                e.status = "1";
                entity.SaveChanges();
                ModelState.Clear();
                e = null;
                return RedirectToAction("manageEvents", "Admin");
            }
        }

        public ActionResult closeEvent(int id)
        {
            using (synchronicDBEntities entity = new synchronicDBEntities())
            {
                Event e = entity.EventSet.Find(id);
                e.status = "2";
                entity.SaveChanges();
                ModelState.Clear();
                e = null;
                return RedirectToAction("manageEvents", "Admin");
            }
        }

        public ActionResult lockEvent(int id)
        {
            using (synchronicDBEntities entity = new synchronicDBEntities())
            {
                Event e = entity.EventSet.Find(id);
                e.status = "0";
                entity.SaveChanges();
                ModelState.Clear();
                e = null;
                return RedirectToAction("manageEvents", "Admin");
            }
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
                return RedirectToAction("manageEvents", "Admin");
            }
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
                return RedirectToAction("manageEvents", "Admin", new { ViewBag.Error });
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
                    return RedirectToAction("manageEvents", "Admin");
                }
            }
            return View(e);
        }

        public ActionResult editUser(int id)
        {
            if ((Session["LoggedUserRole"] as String) == "1")
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    User e = entity.UserSet.Find(id);
                    return View(e);
                }
            }
            else
            {
                ViewBag.Error = "You must be admin to do this action !";
                return RedirectToAction("manageUsers", "Admin", new { ViewBag.Error });
            }
        }

        [HttpPost]
        public ActionResult editUser(User e)
        {
            if (ModelState.IsValid)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    entity.UserSet.Attach(e);
                    entity.Entry(e).State = EntityState.Modified;
                    entity.SaveChanges();
                    ModelState.Clear();
                    e = null;
                    return RedirectToAction("manageUsers", "Admin");
                }
            }
            return View(e);
        }

        public ActionResult deleteUser(int id)
        {
            using (synchronicDBEntities entity = new synchronicDBEntities())
            {
                User u = entity.UserSet.Find(id);
                entity.UserSet.Remove(u);
                entity.SaveChanges();
                u = null;
                return RedirectToAction("manageUsers", "Admin");
            }
        }

        public ActionResult createUser()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult createUser(User u)
        {
            if (ModelState.IsValid)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    if (u.role == null)
                    {
                        u.role = "0";
                    }
                    entity.UserSet.Add(u);
                    entity.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    return RedirectToAction("manageUsers", "Admin");
                }
            }
            return View(u);
        }
    }
}
