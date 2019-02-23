using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using Online_Music_Library.Models;

namespace Online_Music_Library.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection conLog = new SqlConnection();
        SqlCommand comLog = new SqlCommand();
        SqlDataReader drLog;
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            conLog.ConnectionString = "data source=DESKTOP-1RVC546;database=Online_Music_Library;integrated security=SSPI;";
        }

        [HttpPost]
        public ActionResult Verification(Login log)
        {
            connectionString();
            conLog.Open();
            comLog.Connection = conLog;
            comLog.CommandText = "select user_name,password from tblUser where user_name='"+log.user_name+"' and password='"+log.password+"'";
            drLog = comLog.ExecuteReader();
            if(drLog.Read())
            {
                conLog.Close();
                return View("Create");
            }
            else
            {
                conLog.Close();
                return View("Error");
            }
            
           
        }
    }
}