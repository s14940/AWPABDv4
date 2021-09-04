using AWPABD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWPABD.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(AWPABD.Models.Logins loginsModel)
        {
            using (AWPABDEntities db = new AWPABDEntities())
            {
                var loginDetails = db.Logins.Where(x => x.Login == loginsModel.Login && x.Haslo == loginsModel.Haslo).FirstOrDefault();
                if (loginDetails == null)
                {
                    loginsModel.LoginErrorMessage = "Błedna nazwa użytkowniak lub hasło";
                    return View("Index",loginsModel);
                }
                else
                {
                    Session["loginID"] = loginDetails.Id;
                    Session["loginName"] = loginDetails.Login;
                    return RedirectToAction("Index", "Home");
                }
            }
            
        }
        public ActionResult LogOut()
        {
            int loginId =  (int)Session["loginID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}