namespace frez0003_FoodBankMelbourne.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Res_Comments
    {
        public int Id { get; set; }

        [Required]
        public string Cus_Init { get; set; }

        [Required]
        public string Com_String { get; set; }

        public decimal? Com_Rate { get; set; }

        public int R_Id { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
