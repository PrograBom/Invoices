﻿// <auto-generated />
using System;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Invoices.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231104150701_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InvoiceItem", b =>
                {
                    b.Property<int>("InvoicesId")
                        .HasColumnType("int");

                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.HasKey("InvoicesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("InvoiceItem");
                });

            modelBuilder.Entity("Invoices.Model.ClientDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("TaxId")
                        .HasColumnType("longtext");

                    b.Property<string>("VatId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ClientDetails");
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("DATE");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientDetailId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Invoices.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("InvoiceIds")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Invoices.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Invoices.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("BankNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("ClientDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientDetailId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InvoiceItem", b =>
                {
                    b.HasOne("Invoices.Model.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoices.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.HasOne("Invoices.Model.ClientDetail", "ClientDetail")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientDetail");
                });

            modelBuilder.Entity("Invoices.Model.Item", b =>
                {
                    b.HasOne("Invoices.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Invoices.Model.User", b =>
                {
                    b.HasOne("Invoices.Model.ClientDetail", "ClientDetail")
                        .WithMany()
                        .HasForeignKey("ClientDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientDetail");
                });

            modelBuilder.Entity("Invoices.Model.ClientDetail", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
