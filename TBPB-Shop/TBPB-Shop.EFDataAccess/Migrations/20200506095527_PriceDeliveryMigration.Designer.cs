﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBPB_Shop.EFDataAccess;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20200506095527_PriceDeliveryMigration")]
    partial class PriceDeliveryMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NoOfItems")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.OrderData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressBilling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmountCardPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVVCardPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityBilling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatePlacedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DistrictBilling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpireDateCardPayment")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameBilling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCardPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberCardPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneBilling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceDelivery")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalProductsPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TypeBilling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeDelivery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypePayment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Producer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProducerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityOnStoc")
                        .HasColumnType("int");

                    b.Property<decimal>("WarrantyOneYear")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WarrantyTwoYears")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.ProductCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCart");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.ProductOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Customer", b =>
                {
                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Product", b =>
                {
                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.ProductCart", b =>
                {
                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.ProductOrder", b =>
                {
                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.OrderData", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.ProductCart", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}