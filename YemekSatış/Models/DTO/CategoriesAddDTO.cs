using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models.DTO
{
    public class CategoriesAddDTO
    {
        public string food_catagory_name { get; set; }
        public Nullable<long> userid { get; set; }
    }
}