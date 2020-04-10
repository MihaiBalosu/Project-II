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
    [Migration("20200409171835_InitialModel")]
    partial class InitialModel
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
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NoOfItems")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Producer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProducerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityInCart")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOnStoc")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProducerID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Customer", b =>
                {
                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartID");
                });

            modelBuilder.Entity("TBPB_Shop.ApplicationLogic.Models.Product", b =>
                {
                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Cart", null)
                        .WithMany("Product")
                        .HasForeignKey("CartID");

                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.HasOne("TBPB_Shop.ApplicationLogic.Models.Producer", null)
                        .WithMany("Products")
                        .HasForeignKey("ProducerID");
                });
#pragma warning restore 612, 618
        }
    }
}
