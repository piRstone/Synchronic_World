using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synchronic_World.Models;

namespace Synchronic_World.Controllers
{
    public class FriendsController : Controller
    {
        //public ActionResult findFriend()
        //{
        //    synchronicDBEntities entity = new synchronicDBEntities();
        //    return View(entity.UserSet);
        //}

        public ViewResult findFriend(String searchString)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            //var users = from u in .User; 
            //               select u;
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        users = users.OrderByDescending(model => model.LastName);
            //        break;
            //    case "Date":
            //        users = users.OrderBy(model => model.EnrollmentDate);
            //        break;
            //    case "date_desc":
            //        users = users.OrderByDescending(model => model.EnrollmentDate);
            //        break;
            //    default:
            //        users = users.OrderBy(model => model.LastName);
            //        break;
            //}
            //return View(users.ToList());


            using (synchronicDBEntities entity = new synchronicDBEntities()) {
                var users = from u in entity.UserSet
                           select u;

                if (!String.IsNullOrEmpty(searchString))
                {
                    users = users.Where(model => model.lastname.Contains(searchString)
                                           || model.firstname.Contains(searchString));
                }
                return View(users.ToList());
            }
            
        }

        public ActionResult addFriend(int id)
        {
            using (synchronicDBEntities entity = new synchronicDBEntities())
            {
                Friends f = new Friends();
                f.userId = Session["LoggedUserId"] as String;
                f.friendId = id.ToString();
                entity.FriendsSet.Add(f);
                entity.SaveChanges();
                ViewBag.Ok = "Friend successfully added !";
                return RedirectToAction("findFriend", "Friends");
            }
        }

        public ActionResult myFriends()
        {
            using(synchronicDBEntities entity = new synchronicDBEntities())
            {
                var user = Session["LoggedUserId"];
                var friends = entity.FriendsSet.Where(model => model.userId.Equals(user));

                return View(friends);
            }
        }

    }
}
