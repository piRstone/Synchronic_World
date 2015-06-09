using Synchronic_World.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(User u)
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
                    Session["LoggedUserId"] = u.Id.ToString();
                    Session["LoggedUserFirstname"] = u.firstname.ToString();
                    Session["LoggedUserRole"] = u.role.ToString();
                    return RedirectToAction("Event", "Event");
                }
            }
            return View(u);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    var login = entity.UserSet.Where(a => a.mail.Equals(u.mail) && a.password.Equals(u.password)).FirstOrDefault();
                    if (login != null)
                    {
                        Session["LoggedUserId"] = login.Id.ToString();
                        Session["LoggedUserFirstname"] = login.firstname.ToString();
                        Session["LoggedUserRole"] = login.role.ToString();
                        return RedirectToAction("Event", "Event");
                    }
                }
            }
            else
            {
                ViewBag.Error = "Something is wrong :$";
            }
            return View(u);
        }

        public ActionResult Disconnect()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult userProfile(int id)
        {
            if ((Session["LoggedUserId"] as String) != null)
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
                return RedirectToAction("Event", "Event");
            }
        }

        [HttpPost]
        public ActionResult userProfile(User u)
        {
            if (ModelState.IsValid)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    if (u.role == null)
                    {
                        u.role = "0";
                    }
                    entity.UserSet.Attach(u);
                    entity.Entry(u).State = EntityState.Modified;
                    entity.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    return RedirectToAction("userProfile", "User");
                }
            }
            return View(u);
        }

        //public ActionResult resetPassword(int id)
        //{
        //    if ((Session["LoggedUserId"] as String) != null)
        //    {
        //        using (synchronicDBEntities entity = new synchronicDBEntities())
        //        {
        //            Event e = entity.EventSet.Find(id);
        //            return View(e);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        //[HttpPost]
        //public ActionResult resetPassword(User u)
        //{
        //    return null;
        //}
    }
}
