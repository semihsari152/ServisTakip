﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServisTakipWebAPI.Models;

#nullable disable

namespace ServisTakipWebAPI.Migrations
{
    [DbContext(typeof(ServisTakipDbContext))]
    [Migration("20240122133659_migg_add_entities")]
    partial class migg_add_entities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServisTakipWebAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("CustomerCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCounty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ServisTakipWebAPI.Models.FaultTrack", b =>
                {
                    b.Property<int>("FaultTrackingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FaultTrackingID"));

                    b.Property<DateTime>("EstimatedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FaultCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FaultDefinition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaultDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaultDocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaultStage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FaultUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FaultWorkerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("FaultTrackingID");

                    b.HasIndex("ProductID");

                    b.ToTable("FaultTracks");
                });

            modelBuilder.Entity("ServisTakipWebAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<string>("ProductAccessories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductSerialNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ServisTakipWebAPI.Models.FaultTrack", b =>
                {
                    b.HasOne("ServisTakipWebAPI.Models.Product", "Product")
                        .WithMany("FaultTrack")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ServisTakipWebAPI.Models.Product", b =>
                {
                    b.Navigation("FaultTrack");
                });
#pragma warning restore 612, 618
        }
    }
}