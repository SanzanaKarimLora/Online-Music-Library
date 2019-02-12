using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Music_Library.Models;

namespace Online_Music_Library.Controllers
{
    public class UserController : Controller
    {
       
        [HttpGet]
        public ActionResult Register(int id=0)
        {
            tblUser userModel = new tblUser();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Register(tblUser userModel)
        {
            using (Online_Music_LibraryEntities dbModel_user = new Online_Music_LibraryEntities() )
            {
                if(dbModel_user.tblUsers.Any(x=>x.user_name==userModel.user_name))
                {
                    ViewBag.DuplicateMessage = "User name already exists!!!";
                    return View("Register", userModel);

                }
                dbModel_user.tblUsers.Add(userModel);
                dbModel_user.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successfully Registered";
            return View("Register", new tblUser());
        }

    }
}