﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models.DTO
{
    public class SubCategoriesListDTO
    {
        public int food_id { get; set; }
        public string food_name { get; set; }
        public string food_img_src { get; set; }
        public byte food_catagory_id { get; set; }
        public bool food_status { get; set; }
    }
}