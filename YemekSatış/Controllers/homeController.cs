using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSatış.Models;
using YemekSatış.Models.DTO;

namespace YemekSatış.Controllers
{
    public class homeController : Controller
    {
        private evyemegiEntities1 db = new evyemegiEntities1();
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult MutfakListesiYukle()
        {
            List<CategoriesListDTO> mutfak = db.food_catagory.Select(s=> new CategoriesListDTO {
                food_catagory_id=s.food_catagory_id,
                food_catagory_name=s.food_catagory_name,
            }).ToList();
            return Json(mutfak, JsonRequestBehavior.AllowGet);
        }
    }
}