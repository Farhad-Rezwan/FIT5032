namespace CommentRichText.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LabAssessment3_Models : DbContext
    {
        public LabAssessment3_Models()
            : base("name=LabAssessment3_Models")
        {
        }

        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.Comments)
                .IsUnicode(false);
        }
    }
}
