using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekSatış.Models
{
    public class Kalitim
    {
     public evyemegiEntities db { get; set; }
        public Kalitim()
        {
            db = new evyemegiEntities();

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