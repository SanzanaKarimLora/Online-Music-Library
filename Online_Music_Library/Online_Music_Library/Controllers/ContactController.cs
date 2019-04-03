using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Music_Library.Models;

namespace Online_Music_Library.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        // GET: Contact
        public ActionResult Contact(int id=0)
        {
            Contact contactModel = new Contact();
            return View(contactModel);
        }

        [HttpPost]
        public ActionResult Contact(Contact contactModel)
        {
            using (AppDBEntities dbModel = new AppDBEntities())
            {

                dbModel.Contacts.Add(contactModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Message sent";
            return View("Contact", new Contact());
        }
    }
}