using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models.DTO
{
    public class BasketAddDTO
    {
       
        public long CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> SKU { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<long> userid { get; set; }
    }
}