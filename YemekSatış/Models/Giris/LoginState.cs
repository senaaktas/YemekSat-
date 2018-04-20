using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YemekSatış.Models.DTO;

namespace YemekSatış.Models.Giris
{
    public class LoginState
    {
        private evyemegiEntities1 db;
        public LoginState()
        {
            db = new evyemegiEntities1();
        }
        public bool IsLoginSucces(string user , string pas)
        {
            user resultUser = db.user.Where(x => x.user_email.Equals(user) && x.user_password_salt.Equals(pas)).FirstOrDefault();
                if (resultUser != null)
            {
                SabitlerDTO.KullaniciID = resultUser.user_id;
                resultUser.user_create_date = DateTime.Now;
                db.Entry(resultUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}