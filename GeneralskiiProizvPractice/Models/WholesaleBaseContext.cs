using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GeneralskiiProizvPractice.Models;

public partial class WholesaleBaseContext : DbContext
{
    public WholesaleBaseContext()
    {
    }

    public WholesaleBaseContext(DbContextOptions<WholesaleBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IREDSCJ\\SQLEXPRESS; Database=WholesaleBase; User=alnix; Password=123; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryNumber).HasName("PK__Deliveri__A50E8E2312433D98");

            entity.Property(e => e.DeliveryNumber)
                .ValueGeneratedNever()
                .HasColumnName("Delivery_Number");
            entity.Property(e => e.DeliveryDate).HasColumnName("Delivery_Date");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Invoice_Number");
            entity.Property(e => e.ProductCode).HasColumnName("Product_Code");
            entity.Property(e => e.QuantitySupplied).HasColumnName("Quantity_Supplied");
            entity.Property(e => e.SupplierNumber).HasColumnName("Supplier_Number");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ProductCode)
                .HasConstraintName("FK__Deliverie__Produ__07C12930");

            entity.HasOne(d => d.SupplierNumberNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.SupplierNumber)
                .HasConstraintName("FK__Deliverie__Suppl__06CD04F7");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductCode).HasName("PK__Products__74FCFA1F06DFB47C");

            entity.Property(e => e.ProductCode)
                .ValueGeneratedNever()
                .HasColumnName("Product_Code");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Product_Name");
            entity.Property(e => e.QuantityInStock).HasColumnName("Quantity_In_Stock");
            entity.Property(e => e.UnitOfMeasurement)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Unit_of_Measurement");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Unit_Price");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierNumber).HasName("PK__Supplier__EC84D1A215E9029E");

            entity.Property(e => e.SupplierNumber)
                .ValueGeneratedNever()
                .HasColumnName("Supplier_Number");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Full_Name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
