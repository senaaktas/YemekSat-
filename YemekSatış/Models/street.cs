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
    
    public partial class street
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public street()
        {
            this.user = new HashSet<user>();
        }
    
        public int street_id { get; set; }
        public short city_id { get; set; }
        public short town_id { get; set; }
        public short district_id { get; set; }
        public string street_name_uppercase { get; set; }
        public string street_name { get; set; }
        public string street_name_lowercase { get; set; }
    
        public virtual city city { get; set; }
        public virtual district district { get; set; }
        public virtual town town { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user { get; set; }
    }
}
