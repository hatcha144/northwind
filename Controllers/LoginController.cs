using NorthwindDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindDatabase.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Authorize(NorthwindDatabase.Models.User userModel)
        {
            using (LogInDataBaseEntities1 db = new LogInDataBaseEntities1())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Passwrod == x.Passwrod).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password";
                    return View("Index", userModel);
                }
                else
                {
                    Session["UserName"] = userDetails.UserName;
                    Session["UserID"] = userDetails.UserID;
                    return RedirectToAction("Index", "Customers");
                }
            }

        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
