using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Mvc;
using Online_Music_Library.Models;

namespace Online_Music_Library.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection conAdmin = new SqlConnection();
        SqlCommand comAdmin = new SqlCommand();
        SqlDataReader drAdmin;
        // GET: Login
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        void connectionString()
        {
            conAdmin.ConnectionString = "data source=DESKTOP-1RVC546;database=Online_Music_Library;integrated security=SSPI;";
        }
        

        [HttpPost]
        public ActionResult Verification(Admin admin)
        {
            connectionString();
            conAdmin.Open();
            comAdmin.Connection = conAdmin;
            comAdmin.CommandText = "select Admin_name,Admin_password from tblAdministrator where Admin_name='" + admin.Admin_name + "' and Admin_password='" + admin.Admin_password + "'";
            drAdmin = comAdmin.ExecuteReader();
            if (drAdmin.Read())
            {
                conAdmin.Close();
                return View("WelcomeAdmin");
            }
            else
            {
                conAdmin.Close();
                return View("Sorry");
            }


        }
    }
}