//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodBankMelbourne_frez0003.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            this.Cust_Booking = new HashSet<Cust_Booking>();
            this.Res_Comments = new HashSet<Res_Comments>();
            this.Res_Location = new HashSet<Res_Location>();
        }

        public int Id { get; set; }
        [AllowHtml]
        public string R_Name { get; set; }
        [AllowHtml]
        public string Descrip { get; set; }
        [AllowHtml]
        public string RT_Service { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cust_Booking> Cust_Booking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Res_Comments> Res_Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Res_Location> Res_Location { get; set; }
    }
}
