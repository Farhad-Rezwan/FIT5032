namespace frez0003_FoodBankMelbourne.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Res_Location
    {
        public int Id { get; set; }

        [Required]
        public string L_Name { get; set; }

        [Required]
        public string S_Address { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Longitude { get; set; }

        public int Res_Id { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
