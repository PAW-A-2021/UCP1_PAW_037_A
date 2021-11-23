using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_037_A.Models
{
    public partial class SportStoreContext : DbContext
    {
        public SportStoreContext()
        {
        }

        public SportStoreContext(DbContextOptions<SportStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartLine> CartLines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<CartLine>(entity =>
            {
                entity.ToTable("CartLine");

                entity.Property(e => e.CartLineId)
                    .ValueGeneratedNever()
                    .HasColumnName("CartLineID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CartLines)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_CartLine_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartLines)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CartLine_Products");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Line1).IsRequired();

                entity.Property(e => e.Line2).IsRequired();

                entity.Property(e => e.Line3).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.State).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
