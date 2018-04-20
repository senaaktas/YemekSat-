using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSatış.Models;
using YemekSatış.Models.DTO;

namespace YemekSatış.Controllers
{
    public class PanelController : Controller
    {
        private evyemegiEntities1 db = new evyemegiEntities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            List<city> memleket = db.city.ToList();
            ViewBag.slc_City = memleket;
            return View();

        }
        [HttpPost]
        public JsonResult ProfilBilgileriDuzenle(ProfileListDTO entity)
        {
            try
            {
                var profil = db.user.Where(x => x.user_id == SabitlerDTO.KullaniciID).FirstOrDefault();
                profil.user_name = entity.user_name;
                profil.user_email = entity.user_email;
                profil.user_password_salt = entity.user_password_salt;
                profil.city_id = entity.city_id;
                profil.user_cep = entity.user_cep;
                db.SaveChanges();
                return Json(profil, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public JsonResult ProfilBilgileriYukle()
        {
            try
            {
                ProfileListDTO profile = db.user.Where(x => x.user_id == SabitlerDTO.KullaniciID).Select(s => new ProfileListDTO
                {
                    user_id = s.user_id,
                    user_name = s.user_name,
                    user_email = s.user_email,
                    user_password_salt = s.user_password_salt,
                    city_id = s.city_id,
                    user_cep = s.user_cep,
                }).FirstOrDefault();
                return Json(profile, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ActionResult Categories()
        {
            List<CategoriesListDTO> list = db.food_catagory.Where(x => x.food_catagory_id != null).Select(s => new CategoriesListDTO
            {
                food_catagory_id = s.food_catagory_id,
                food_catagory_name = s.food_catagory_name,
            }).OrderByDescending(c => c.food_catagory_id).ToList();
            return View(list);
        }
        [HttpPost]
        public JsonResult KategoriYeni(CategoriesAddDTO entity)
        {
            try
            {
                food_catagory kategori = new food_catagory();
                kategori.food_catagory_name = entity.food_catagory_name;
                db.food_catagory.Add(kategori);
                db.SaveChanges();
                return Json(kategori, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }

        }
        [HttpPost]
        public JsonResult KategoriDuzenle(CategoriesEditDTO entity)
        {
            try
            {
                var kategori = db.food_catagory.Where(x => x.food_catagory_id == entity.food_catagory_id).FirstOrDefault();
                kategori.food_catagory_name = entity.food_catagory_name;
                db.SaveChanges();
                return Json(kategori, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public JsonResult KategoriBilgisiYukle(int id)
        {
            try
            {
                CategoriesEditDTO list = db.food_catagory.Where(x => x.food_catagory_id ==id).Select(s => new CategoriesEditDTO
                {
                    food_catagory_id = s.food_catagory_id,
                    food_catagory_name = s.food_catagory_name
                }).FirstOrDefault();
                return Json(list,JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public JsonResult KategoriSil(int id)
        {
            var kategori = db.food_catagory.Find(id);
            if (kategori != null)
            {
                db.food_catagory.Remove(kategori);
                db.SaveChanges();
            }
            return Json(kategori,JsonRequestBehavior.AllowGet);
        }
        public ActionResult SubCategories()
        {
            List<food_catagory> anaKategori = db.food_catagory.ToList();
            ViewBag.slc_Categories = anaKategori;

            List<SubCategoriesListDTO> list = db.foods.Where(x => x.food_id != null).Select(s => new SubCategoriesListDTO
            {
                food_id=s.food_id,
                food_name=s.food_name,
                CategoryName=s.food_catagory.food_catagory_name,
            }).OrderByDescending(c => c.food_id).ToList();
            return View(list);
        }
        [HttpPost]
        public JsonResult AltKategoriYeni(SubCategoriesAddDTO entity)
        {
            try
            {
                foods kategori = new foods();
                kategori.food_catagory_id = entity.food_catagory_id;
                kategori.food_name = entity.food_name;
                kategori.food_status = true;
                db.foods.Add(kategori);
                db.SaveChanges();
                return Json(kategori, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }

        }
        [HttpPost]
        public JsonResult AltKategoriDuzenle(SubCategoriesEditDTO entity)
        {
            try
            {
                var kategori = db.foods.Where(x => x.food_id == entity.food_id).FirstOrDefault();
                kategori.food_catagory_id = entity.food_catagory_id;
                kategori.food_name = entity.food_name;
                db.SaveChanges();
                return Json(kategori, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public JsonResult AltKategoriBilgisiYukle(int id)
        {
            try
            {
                SubCategoriesEditDTO list = db.foods.Where(x => x.food_id == id).Select(s => new SubCategoriesEditDTO
                {
                    food_id=s.food_id,
                    food_catagory_id = s.food_catagory_id,
                    food_name = s.food_name
                }).FirstOrDefault();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public JsonResult AltKategoriSil(int id)
        {
            var kategori = db.foods.Find(id);
            if (kategori != null)
            {
                db.foods.Remove(kategori);
                db.SaveChanges();
            }
            return Json(kategori, JsonRequestBehavior.AllowGet);
        }
    }
}