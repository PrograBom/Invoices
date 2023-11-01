﻿// <auto-generated />
using System;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Invoices.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ClientDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TaxId")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VatId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ClientDetails");
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ClientDetailsId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("IssueDate")
                        .HasColumnType("DATE");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientDetailsId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Invoices.Model.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("InvoiceId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("BankNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("InvoiceId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClientDetails", b =>
                {
                    b.HasOne("User", "User")
                        .WithOne("ClientDetails")
                        .HasForeignKey("ClientDetails", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.HasOne("ClientDetails", "ClientDetails")
                        .WithMany()
                        .HasForeignKey("ClientDetailsId");

                    b.Navigation("ClientDetails");
                });

            modelBuilder.Entity("Invoices.Model.Item", b =>
                {
                    b.HasOne("Invoices.Model.Invoice", "Invoice")
                        .WithMany("Items")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("Invoices.Model.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("ClientDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
