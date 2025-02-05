﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace test.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Repair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Mileage")
                        .HasColumnType("real");

                    b.Property<int>("RepairStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("RepairTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VehicleId")
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

                    b.Property<Guid?>("ShopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("RepairTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43ff72a4-a37f-459a-a7cc-77f6ae345cab"),
                            Cost = 5000f,
                            Name = "Выправление вмятин"
                        },
                        new
                        {
                            Id = new Guid("7a1b5213-8781-4ff2-81b8-12962553f6c0"),
                            Cost = 8000f,
                            Name = "Замена масла"
                        },
                        new
                        {
                            Id = new Guid("012e7144-a42f-4db7-9b35-21a0f85c5082"),
                            Cost = 500000f,
                            Name = "Замена двигателя"
                        },
                        new
                        {
                            Id = new Guid("b2231e87-09a8-4505-90f5-5880f9f05914"),
                            Cost = 2500f,
                            Name = "Замена колес/покрышек"
                        },
                        new
                        {
                            Id = new Guid("34195d1e-b325-4f56-aa64-d8d11067597d"),
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("7bc39ced-d354-434b-a51e-fc81f4726165"),
                            IdNumber = "1234567890",
                            Name = "СТО 'Акула'"
                        });
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.HasOne("Shop", "Shop")
                        .WithMany("Clients")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Repair", b =>
                {
                    b.HasOne("Client", "Client")
                        .WithMany("Repairs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairType", "RepairType")
                        .WithMany()
                        .HasForeignKey("RepairTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop", "Shop")
                        .WithMany("Repairs")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("RepairType");

                    b.Navigation("Shop");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("RepairType", b =>
                {
                    b.HasOne("Shop", null)
                        .WithMany("RepairTypes")
                        .HasForeignKey("ShopId");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("Client", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Client", b =>
                {
                    b.Navigation("Repairs");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Shop", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Repairs");

                    b.Navigation("RepairTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
