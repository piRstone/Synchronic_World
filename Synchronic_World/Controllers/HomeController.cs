using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synchronic_World.Models;

namespace Synchronic_World.Controllers
{
    public class HomeController : Controller
    {
        synchronicDBEntities entity = new synchronicDBEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["LoggedUserId"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Event", "Event");
            }
        }
    }
}
