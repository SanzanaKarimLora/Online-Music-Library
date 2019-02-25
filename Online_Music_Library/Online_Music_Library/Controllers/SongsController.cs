using Online_Music_Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Music_Library.Controllers
{
    public class SongsController : Controller
    {
        public DbSet<Songs> song { get; set; }
        // GET: Songs
        public ActionResult Index()
        {
            return View();
        }
    }
}