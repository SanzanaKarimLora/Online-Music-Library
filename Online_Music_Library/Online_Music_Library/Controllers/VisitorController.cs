using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Online_Music_Library.Models;

namespace Online_Music_Library.Controllers
{
    public class VisitorController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-1RVC546;Initial Catalog=Online_Music_Library;Integrated Security=SSPI";
        [HttpGet]
        public ActionResult Visitor()
        {
            DataTable dtblSong = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM tblSongs", sqlCon);
                sqlda.Fill(dtblSong);
            }
            return View(dtblSong);
        }



        public ActionResult VisitorView(int id)
        {
            DataTable dtblSong = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM tblSongs where song_id=105", sqlCon);
                sqlda.Fill(dtblSong);
            }
            return View(dtblSong);
        }







    }
}
