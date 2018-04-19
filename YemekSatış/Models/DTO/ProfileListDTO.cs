using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models.DTO
{
    public class ProfileListDTO
    {
        public long user_id { get; set; }
        public string user_nickname { get; set; }
        public string user_name { get; set; }
        public short city_id { get; set; }
        public short town_id { get; set; }
        public short district_id { get; set; }
        public int street_id { get; set; }
        public string user_email { get; set; }
        public string user_password_salt { get; set; }
        public bool user_active { get; set; }
        public Nullable<bool> user_status { get; set; }
        public System.DateTime user_create_date { get; set; }
        public string user_create_ip { get; set; }
        public System.DateTime user_update_date { get; set; }
        public long user_cep { get; set; }
        public Nullable<double> user_score { get; set; }
        public bool admin_status { get; set; }
    }
}