using Synchronic_World.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synchronic_World.Controllers
{
    public class ContributionController : Controller
    {
        //
        // GET: /Contribution/

        public ActionResult Contribution(int id)
        {
            if ((Session["LoggedUserId"] as String) != null)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    Contribution c = new Contribution();
                    c.EventId = id;
                    return View(c);
                }
            }
            else
            {
                return RedirectToAction("Event", "Event", new { ViewBag.Error });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contribution(Contribution c)
        {
            if (ModelState.IsValid)
            {
                using (synchronicDBEntities entity = new synchronicDBEntities())
                {
                    int userId = Convert.ToInt32(Session["LoggedUserId"]);
                    User u = entity.UserSet.Find(userId);
                    c.User = u;
                    entity.ContributionSet.Add(c);
                    entity.SaveChanges();
                    ModelState.Clear();
                    c = null;
                    return RedirectToAction("Event", "Event");
                }
            }
            return View(c);
        }

        public ActionResult seeContributions(int id)
        {
            //using(synchronicDBEntities entity = new synchronicDBEntities())
            //{
            //    var contribs = entity.ContributionSet.Where(model => model.EventId.Equals(id));
            //    return View(entity.ContributionSet);
            //}
            synchronicDBEntities entity = new synchronicDBEntities();
            return View(entity.ContributionSet);
        }
    }
}
