using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YemekSatış.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        public ActionResult GirisYap1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap1(string Username, string Password)
        {
            if(new Models.Giris.LoginState().IsLoginSucces(Username, Password))
            {
                return RedirectToAction("Index", "home");

            }
            return RedirectToAction("GirisYap1", "Giris");
        }
    }
}