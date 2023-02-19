using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopApp3.Areas.Identity.Data;

namespace ShopApp3.Models;

public partial class RtvDatabaseContext : ApplicationDbContext
{
    public RtvDatabaseContext(DbContextOptions<RtvDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //modelBuilder.Entity<Customer>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("customer_id");

        //    entity.HasIndex(e => e.Mail, "UQ__Customer__7A212904478434A7").IsUnique();

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.City)
        //        .HasMaxLength(50)
        //        .HasColumnName("city");
        //    entity.Property(e => e.CompanyName)
        //        .HasMaxLength(50)
        //        .HasColumnName("company_name");
        //    entity.Property(e => e.CompanyNumber).HasColumnName("company_number");
        //    entity.Property(e => e.CustomerName)
        //        .HasMaxLength(50)
        //        .HasColumnName("customer_name");
        //    entity.Property(e => e.FlatNumber).HasColumnName("flat_number");
        //    entity.Property(e => e.Mail)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("mail");
        //    entity.Property(e => e.PhoneNumber)
        //        .HasMaxLength(12)
        //        .IsUnicode(false)
        //        .IsFixedLength()
        //        .HasColumnName("phone_number");
        //    entity.Property(e => e.PostCode)
        //        .HasMaxLength(6)
        //        .IsUnicode(false)
        //        .HasColumnName("post_code");
        //    entity.Property(e => e.Street)
        //        .HasMaxLength(50)
        //        .HasColumnName("street");
        //    entity.Property(e => e.StreetNumber).HasColumnName("street_number");
        //    entity.Property(e => e.Surname)
        //        .HasMaxLength(50)
        //        .HasColumnName("surname");
        //});

        //modelBuilder.Entity<Employee>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("employee_id");

        //    entity.Property(e => e.Id).HasColumnName("id");

        //    entity.Property(e => e.EmployeeName)
        //        .HasMaxLength(50)
        //        .HasColumnName("employee_name");
        //    entity.Property(e => e.EmployeeSurname)
        //        .HasMaxLength(50)
        //        .HasColumnName("employee_surname");
        //});

        //modelBuilder.Entity<Invoice>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("invoice_id");

        //    entity.HasIndex(e => e.InvoiceName, "UQ__Invoices__77281D7C00C98EBE").IsUnique();

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.DateOfInvoice)
        //        .HasColumnType("datetime")
        //        .HasColumnName("date_of_invoice");
        //    entity.Property(e => e.InvoiceName)
        //        .HasMaxLength(12)
        //        .IsUnicode(false)
        //        .HasColumnName("invoice_name");
        //});

        //modelBuilder.Entity<Order>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("order_id");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.CustomerId).HasColumnName("customer_id");
        //    entity.Property(e => e.DateOfPlacingTheOrder)
        //        .HasColumnType("datetime")
        //        .HasColumnName("date_of_placing_the_order");
        //    entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
        //    entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
        //    entity.Property(e => e.OrderRealizationDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("order_realization_date");
        //    entity.Property(e => e.ShippingDate)
        //        .HasColumnType("datetime")
        //        .HasColumnName("shipping_date");
        //    entity.Property(e => e.WhetherTheOrderFulfilled).HasColumnName("whether_the_order_fulfilled");

        //    entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.CustomerId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("id_customer");

        //    entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.EmployeeId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("id_employee");

        //    entity.HasOne(d => d.Invoice).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.InvoiceId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("id_invoice");
        //});

        //modelBuilder.Entity<OrderedProduct>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("orderd_products_id");

        //    entity.ToTable("Ordered_products");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.OrderId).HasColumnName("order_id");
        //    entity.Property(e => e.ProductId).HasColumnName("product_id");
        //    entity.Property(e => e.Quantity).HasColumnName("quantity");

        //    entity.HasOne(d => d.Order).WithMany(p => p.OrderedProducts)
        //        .HasForeignKey(d => d.OrderId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("id_order");

        //    entity.HasOne(d => d.Product).WithMany(p => p.OrderedProducts)
        //        .HasForeignKey(d => d.ProductId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("id_product");
        //});

        //modelBuilder.Entity<Producer>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("producer_id");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.ProducerName)
        //        .HasMaxLength(50)
        //        .HasColumnName("producer_name");
        //});

        //modelBuilder.Entity<Product>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("product_id");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.AvailablePieces).HasColumnName("available_pieces");
        //    entity.Property(e => e.CategoryId).HasColumnName("category_id");
        //    entity.Property(e => e.NetCatalogPrice)
        //        .HasColumnType("decimal(6, 2)")
        //        .HasColumnName("net_catalog_price");
        //    entity.Property(e => e.NetSellingPrice)
        //        .HasColumnType("decimal(6, 2)")
        //        .HasColumnName("net_selling_price");
        //    entity.Property(e => e.NetSellingWarehouse)
        //        .HasColumnType("decimal(6, 2)")
        //        .HasColumnName("net_selling_warehouse");
        //    entity.Property(e => e.ProducerId).HasColumnName("producer_id");
        //    entity.Property(e => e.ProductName)
        //        .HasMaxLength(50)
        //        .HasColumnName("product_name");
        //    entity.Property(e => e.VatRate).HasColumnName("VAT_rate");

        //    entity.HasOne(d => d.Category).WithMany(p => p.Products)
        //        .HasForeignKey(d => d.CategoryId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("id_category");

        //    entity.HasOne(d => d.Producer).WithMany(p => p.Products)
        //        .HasForeignKey(d => d.ProducerId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("id_producer");
        //});

        //modelBuilder.Entity<ProductCategory>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("category_id");

        //    entity.ToTable("Product_category");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.CategoryName)
        //        .HasMaxLength(50)
        //        .HasColumnName("category_name");
        //});

        //OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
