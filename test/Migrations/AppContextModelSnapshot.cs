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

                    b.Property<float>("Cost")
                        .HasColumnType("real");

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

                    b.HasKey("Id");

                    b.ToTable("RepairTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52a6ccaf-2d9b-46fa-be70-c2eb2867f002"),
                            Cost = 5000f,
                            Name = "Выправление вмятин"
                        },
                        new
                        {
                            Id = new Guid("bf8ca247-aae1-4cc0-8872-b7cbbfe2ffca"),
                            Cost = 8000f,
                            Name = "Замена масла"
                        },
                        new
                        {
                            Id = new Guid("d1ee9afa-def6-495d-bc84-41ce30379401"),
                            Cost = 500000f,
                            Name = "Замена двигателя"
                        },
                        new
                        {
                            Id = new Guid("ed5c3a76-da10-4e36-8bf2-2b080e4675e7"),
                            Cost = 2500f,
                            Name = "Замена колес/покрышек"
                        },
                        new
                        {
                            Id = new Guid("264e73d9-af15-4219-b0e6-f4944380a921"),
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
                            Id = new Guid("20a97a2f-d061-4c20-bcf9-6060c5e8d96b"),
                            IdNumber = "1237873535",
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
                });
#pragma warning restore 612, 618
        }
    }
}
