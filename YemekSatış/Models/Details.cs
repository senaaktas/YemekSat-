//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YemekSatış.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Details()
        {
            this.Basket = new HashSet<Basket>();
        }
    
        public int Id { get; set; }
        public Nullable<byte> KategoriID { get; set; }
        public Nullable<int> AltKategoriID { get; set; }
        public string Details1 { get; set; }
        public Nullable<int> SKU { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<long> userid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Basket { get; set; }
        public virtual food_catagory food_catagory { get; set; }
        public virtual foods foods { get; set; }
        public virtual user user { get; set; }
    }
}
