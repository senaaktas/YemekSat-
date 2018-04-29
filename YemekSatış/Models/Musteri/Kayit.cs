using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models.Musteri
{
    public class Kayit:Kalitim
    {
        public Kayit ()
        {
            base.db = new evyemegiEntities();           
        }
        public bool KayitOl(KayitModel model)
        {
            user musteri = new user();
            musteri.user_name = model.Username;
            musteri.user_password_salt = model.Password;
            musteri.user_email = model.Email;
            musteri.user_cep = Convert.ToInt64( model.Phone);
            musteri.user_create_date = DateTime.Now;
            musteri.user_update_date = DateTime.Now;
            musteri.city_id = 0;
            musteri.district_id = 0;
            musteri.street_id = 0;
            musteri.town_id = 0; 
            db.user.Add(musteri);
            db.SaveChanges();
            return true;

        }
    }
}