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
            List<SubCategoriesListDTO> list = db.foods.Select(s => new SubCategoriesListDTO
            {
                CategoryName = s.food_catagory.food_catagory_name,
                food_name = s.food_name,
                food_catagory_id = s.food_catagory_id,
                food_id = s.food_id,
            }).OrderBy(z => z.food_name).ToList();

            return View(list);

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
                Price = s.Price,
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
                basket.Price = entity.Price;
                basket.Total = entity.SKU * entity.Price;
                db.Basket.Add(basket);
                db.SaveChanges();
                return Redirect("http://localhost:62175/home/MutfakDetay/?anakategori=" + ana + "&altkategori=" + alt + "");
            }
            return null;
        }
        public ActionResult Sepet()
        {
            List<BasketListDTO> list = db.Basket.Where(x=>x.CustomerID==SabitlerDTO.KullaniciID).Select(s => new BasketListDTO
            {
                BasketID = s.BasketID,
                CustomerID = s.CustomerID,
                DetayName = s.Details.Details1,
                SKU = s.SKU,
                Price = s.Price,             
                Total = s.Total,
               
            }).OrderBy(z => z.BasketID).ToList();

            return View(list);
        }
        public JsonResult SepetSil(int id)
        {
            var sepet = db.Basket.Find(id);
            if (sepet != null)
            {
                db.Basket.Remove(sepet);
                db.SaveChanges();
            }
            return Json(sepet, JsonRequestBehavior.AllowGet);
        }
    }
}