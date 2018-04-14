using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSatış.Models;

namespace YemekSatış.Controllers
{
    public class uyeController : Controller
    {
        evyemegiEntities1 bd = new evyemegiEntities1();
        // GET: uye
        public ActionResult GirisYap()
        {
            ViewBag.Title = "Giriş Yap";
            return View();

        }
        [HttpPost]
        public ActionResult GirisYap(user login)
        {
            if (ModelState.IsValid)
            {
                var cus = bd.user.SingleOrDefault(d => d.user_name.Equals(login.user_name) && d.user_password_salt.Equals(login.user_password_salt));
                if (cus != null)
                {
                    Session["loginkey"] = login;
                    return RedirectToAction("Index", "home");

                }
                
            }
            ViewBag.Title = "Giriş Yap";


            return View(login);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}