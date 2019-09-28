namespace frez0003_FoodBankMelbourne.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FoodBankMelb_Models1 : DbContext
    {
        public FoodBankMelb_Models1()
            : base("name=FoodBankMelb_Models1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Cust_Booking> Cust_Booking { get; set; }
        public virtual DbSet<Res_Comments> Res_Comments { get; set; }
        public virtual DbSet<Res_Location> Res_Location { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Cust_Booking)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Customer_id);

            modelBuilder.Entity<Res_Comments>()
                .Property(e => e.Com_Rate)
                .HasPrecision(2, 1);

            modelBuilder.Entity<Res_Location>()
                .Property(e => e.L_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Res_Location>()
                .Property(e => e.S_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Res_Location>()
                .Property(e => e.Latitude)
                .HasPrecision(10, 8);

            modelBuilder.Entity<Res_Location>()
                .Property(e => e.Longitude)
                .HasPrecision(11, 8);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Cust_Booking)
                .WithRequired(e => e.Restaurant)
                .HasForeignKey(e => e.Resturent_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Res_Comments)
                .WithRequired(e => e.Restaurant)
                .HasForeignKey(e => e.R_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Res_Location)
                .WithRequired(e => e.Restaurant)
                .HasForeignKey(e => e.Res_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
