namespace Assignment_1_Shoes_200364251.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    
    public partial class ShoesModel : DbContext
    {
        public ShoesModel()
            : base("name=ShoesConnection")
        {
        }

        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<type> types { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<brand>()
                .Property(e => e.brName)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .Property(e => e.brDesc)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .Property(e => e.brFounder)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .HasMany(e => e.types)
                .WithRequired(e => e.brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<type>()
                .Property(e => e.moName)
                .IsFixedLength();

            modelBuilder.Entity<type>()
                .Property(e => e.moDesc)
                .IsFixedLength();

            modelBuilder.Entity<type>()
                .Property(e => e.moColours)
                .IsFixedLength();
        }
    }
}
