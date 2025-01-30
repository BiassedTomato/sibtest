﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace test.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20250130160337_RenameToShops")]
    partial class RenameToShops
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("IdNumber")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Repair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Mileage")
                        .HasColumnType("real");

                    b.Property<int>("RepairStatus")
                        .HasColumnType("integer");

                    b.Property<Guid?>("RepairTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("RepairTypeId");

                    b.HasIndex("ShopId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("RepairType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RepairTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("88ea353e-3635-4fd9-9b01-f95a673b8878"),
                            Cost = 5000f,
                            Name = "Выправление вмятин"
                        },
                        new
                        {
                            Id = new Guid("518c614e-c353-4ebb-b20e-6389295e63cb"),
                            Cost = 8000f,
                            Name = "Замена масла"
                        },
                        new
                        {
                            Id = new Guid("e4bd2f6a-4712-4970-922b-98e4f3702d68"),
                            Cost = 500000f,
                            Name = "Замена двигателя"
                        },
                        new
                        {
                            Id = new Guid("cde01ecb-4511-4b15-97ba-0f5b5b691320"),
                            Cost = 2500f,
                            Name = "Замена колес/покрышек"
                        },
                        new
                        {
                            Id = new Guid("644593eb-f496-49cd-8cb7-ba58eb80a5d4"),
                            Cost = 800f,
                            Name = "Установка радиоприемника"
                        });
                });

            modelBuilder.Entity("Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("IdNumber")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CarNumber")
                        .HasColumnType("text");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Repair", b =>
                {
                    b.HasOne("Client", "Client")
                        .WithMany("Repairs")
                        .HasForeignKey("ClientId");

                    b.HasOne("RepairType", "RepairType")
                        .WithMany()
                        .HasForeignKey("RepairTypeId");

                    b.HasOne("Shop", "Shop")
                        .WithMany("Repairs")
                        .HasForeignKey("ShopId");

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Client");

                    b.Navigation("RepairType");

                    b.Navigation("Shop");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("Client", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Navigation("Repairs");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Shop", b =>
                {
                    b.Navigation("Repairs");
                });
#pragma warning restore 612, 618
        }
    }
}
