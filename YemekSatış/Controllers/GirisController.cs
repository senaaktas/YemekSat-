using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSatış.Models;
using YemekSatış.Models.Musteri;
namespace YemekSatış.Controllers
{
    public class GirisController : Controller
    {
        private evyemegiEntities db = new evyemegiEntities();
        // GET: Giris
        public ActionResult GirisYap1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(KayitModel postData)
        {
            bool result = new Models.Musteri.Kayit().KayitOl(postData);

            return RedirectToAction("GirisYap1", "Giris");
        }
        [HttpPost]
        public ActionResult GirisYap1(string Username, string Password)
        {
            if (new Models.Giris.LoginState().IsLoginSucces(Username, Password))
            {
                return RedirectToAction("Index", "Panel");

            }
            return RedirectToAction("GirisYap1", "Giris");
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("GirisYap1", "Giris");
        }
      
    }
}