namespace frez0003_FoodBankMelbourne.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cust_Booking
    {
        public int Id { get; set; }

        public int Resturent_id { get; set; }

        [StringLength(128)]
        public string Customer_id { get; set; }

        public DateTime Booking_Date_time { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
