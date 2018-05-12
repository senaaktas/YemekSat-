using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models.DTO
{
    public class DetailsListDTO
    {
        public int Id { get; set; }
        public Nullable<byte> KategoriID { get; set; }
        public Nullable<int> AltKategoriID { get; set; }
        public string Details1 { get; set; }
        public Nullable<int> SKU { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<long> userid { get; set; }
        public string KategoriName { get; set; }
    }
}