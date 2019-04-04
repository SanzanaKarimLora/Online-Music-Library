using Online_Music_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Music_Library.Controllers
{
  
    public class SearchFuncController : Controller
    {
        Online_Music_LibraryEntities1 dbSearch = new Online_Music_LibraryEntities1();
        // GET: SearchFunc
        public ActionResult SearchOp(string searching)
        {
            return View(dbSearch.tblSongs.Where(x=>x.song_name.Contains(searching) || searching==null).ToList());
        }
    }
}