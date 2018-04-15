using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models
{
    public class Kalitim
    {
     public evyemegiEntities1 db { get; set; }
        public Kalitim()
        {
            db = new evyemegiEntities1();

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);

        }
        ~Kalitim()
        {
            this.Dispose();
        }
    }
}