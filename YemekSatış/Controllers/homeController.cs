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
        private evyemegiEntities db = new evyemegiEntities();
        static int ana = -1;
        static int alt = -1;
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult MutfakListesiYukle()
        {
            List<CategoriesListDTO> mutfak = db.food_catagory.Select(s => new CategoriesListDTO
            {
                food_catagory_id = s.food_catagory_id,
                food_catagory_name = s.food_catagory_name,
            }).ToList();
            return Json(mutfak, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Mutfaklar(int id)
        {
            List<SubCategoriesListDTO> list = db.foods.Where(x => x.food_catagory_id == id).Select(s => new SubCategoriesListDTO
            {
                CategoryName = s.food_catagory.food_catagory_name,
                food_name = s.food_name,
                food_catagory_id = s.food_catagory_id,
                food_id = s.food_id,
            }).OrderBy(z => z.food_name).ToList();

            return View(list);
        }
        public ActionResult MutfakDetay(int anakategori, int altkategori)
        {
            ana = anakategori;
            alt = altkategori;
            List<DetailsListDTO> list = db.Details.Where(x => x.KategoriID == anakategori && x.AltKategoriID == altkategori).Select(s => new DetailsListDTO
            {
                Id = s.Id,
                Details1 = s.Details1,
            }).OrderBy(k => k.Details1).ToList();
            return View(list);
        }
        public ActionResult SepeteEkle(BasketAddDTO entity)
        {
            if (SabitlerDTO.KullaniciID > 0)
            {
                Basket basket = new Basket();
                basket.CustomerID = SabitlerDTO.KullaniciID;
                basket.ProductID = entity.ProductID;
                basket.SKU = entity.SKU;
                db.Basket.Add(basket);
                db.SaveChanges();
                return Redirect("http://localhost:62175/home/MutfakDetay/?anakategori="+ana+"&altkategori="+alt+"");
            }
            return null;
        }
    }
}