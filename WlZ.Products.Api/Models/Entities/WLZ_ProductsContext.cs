using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WlZ.Products.Api.Models.Entities
{
    public partial class WLZ_ProductsContext : DbContext
    {
        public WLZ_ProductsContext()
        {
        }

        public WLZ_ProductsContext(DbContextOptions<WLZ_ProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS2014; Database=WLZ_Products; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasColumnName("client")
                    .HasMaxLength(100);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("orderDetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrder).HasColumnName("idOrder");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderDetails_order");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderDetails_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.Idsubcategory).HasColumnName("idsubcategory");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdsubcategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Idsubcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_product");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("subcategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategory).HasColumnName("idcategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subcategory_category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
