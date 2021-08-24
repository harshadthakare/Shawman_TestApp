using Shawman_TestApp.EnityModel;
using Shawman_TestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shawman_TestApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Employee_HARSHADEntities db = new Employee_HARSHADEntities();

        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]

        public ActionResult Index(LoginModel LoginVar)
        {
            //bool Status = false;
            TblLogin result = db.TblLogins.Where(m => m.Username == LoginVar.UserName && m.Password == LoginVar.Password).FirstOrDefault();

            if (result != null && result.Username == LoginVar.UserName && result.Password == LoginVar.Password)
            {
                ViewBag.Status = true;
                return RedirectToAction("Index", "Home");

            }

            else
            {

                ViewBag.Message = string.Format("UserName and Password is incorrect");

                return View();

            }

        }
    }
}