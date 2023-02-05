﻿// <auto-generated />
using System;
using Invoices.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Invoices.Migrations
{
    [DbContext(typeof(InvoiceDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Invoices.Model.Client", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BankNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TaxId")
                        .HasColumnType("int");

                    b.Property<int>("VatId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClientId1")
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("IssueDate")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.HasIndex("ClientId1");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Invoices.Model.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItem");
                });

            modelBuilder.Entity("Invoices.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.HasOne("Invoices.Model.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId1");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Invoices.Model.InvoiceItem", b =>
                {
                    b.HasOne("Invoices.Model.Invoice", "Invoice")
                        .WithMany("Items")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Invoices.Model.Client", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Invoices.Model.Invoice", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
