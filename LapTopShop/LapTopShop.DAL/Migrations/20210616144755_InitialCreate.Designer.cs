﻿// <auto-generated />
using System;
using LapTopShop.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LapTopShop.DAL.Migrations
{
    [DbContext(typeof(LapTopDataBaseContext))]
    [Migration("20210616144755_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LapTopShop.Models.DataModels.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConfigurationTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationTypeId");

                    b.ToTable("Configurations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("413e3ddc-7064-404b-8fa5-41f664473177"),
                            ConfigurationTypeId = new Guid("c6536d6b-e9eb-4f60-a0da-66937e1ea5dd"),
                            Price = 535.21m,
                            Value = "8 GB"
                        },
                        new
                        {
                            Id = new Guid("269ed5d8-1273-441b-8839-35f20bb54508"),
                            ConfigurationTypeId = new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"),
                            Price = 635.21m,
                            Value = "16 GB"
                        },
                        new
                        {
                            Id = new Guid("ffbe392e-8812-4831-96c5-dc97b6e79a46"),
                            ConfigurationTypeId = new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"),
                            Price = 535.21m,
                            Value = "500 GB"
                        },
                        new
                        {
                            Id = new Guid("1ad30101-f986-4a53-a11a-db359da3b15e"),
                            ConfigurationTypeId = new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"),
                            Price = 535.21m,
                            Value = "1 TB"
                        },
                        new
                        {
                            Id = new Guid("40f89c10-366e-44b7-b836-130d7ac1471b"),
                            ConfigurationTypeId = new Guid("503d743b-c33d-4789-bfa6-608f512f744a"),
                            Price = 535.21m,
                            Value = "8 GB"
                        },
                        new
                        {
                            Id = new Guid("02c447bc-5093-443e-926a-ead26ef9c92e"),
                            ConfigurationTypeId = new Guid("503d743b-c33d-4789-bfa6-608f512f744a"),
                            Price = 535.21m,
                            Value = "Red"
                        },
                        new
                        {
                            Id = new Guid("c96284ed-2a78-41d6-b888-b437475b774b"),
                            ConfigurationTypeId = new Guid("503d743b-c33d-4789-bfa6-608f512f744a"),
                            Price = 535.21m,
                            Value = "Blue"
                        });
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.ConfigurationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ConfigurationTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6536d6b-e9eb-4f60-a0da-66937e1ea5dd"),
                            Name = "Ram"
                        },
                        new
                        {
                            Id = new Guid("4ebe08ef-e10e-4443-946a-8c19da907998"),
                            Name = "HDD"
                        },
                        new
                        {
                            Id = new Guid("503d743b-c33d-4789-bfa6-608f512f744a"),
                            Name = "Colour"
                        },
                        new
                        {
                            Id = new Guid("7a14a4fe-caeb-42cf-a31f-96952636e155"),
                            Name = "Processor"
                        });
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Laptop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Laptops");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6307149d-74e1-4baf-8b59-a98895217f65"),
                            ManufacturerId = new Guid("0d9ffad1-0149-432b-b94d-3442707160db"),
                            Name = "Bysiness laptop",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("27ce6a5a-8036-41d8-b4a3-24386fb7c971"),
                            ManufacturerId = new Guid("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"),
                            Name = "Gaming laptop",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("0b27d46f-4301-4f3f-b480-383f1b297bee"),
                            ManufacturerId = new Guid("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"),
                            Name = "Lite laptop",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.LaptopConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConfigurationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LaptopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.HasIndex("LaptopId");

                    b.ToTable("LaptopConfigurations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb000c38-19b8-445d-b23f-be079732af99"),
                            ConfigurationId = new Guid("413e3ddc-7064-404b-8fa5-41f664473177"),
                            LaptopId = new Guid("6307149d-74e1-4baf-8b59-a98895217f65")
                        },
                        new
                        {
                            Id = new Guid("f625cf2b-961e-4031-9615-f4b198864957"),
                            ConfigurationId = new Guid("269ed5d8-1273-441b-8839-35f20bb54508"),
                            LaptopId = new Guid("27ce6a5a-8036-41d8-b4a3-24386fb7c971")
                        },
                        new
                        {
                            Id = new Guid("45703ceb-c89d-4abb-80a5-d1a5b8a11288"),
                            ConfigurationId = new Guid("ffbe392e-8812-4831-96c5-dc97b6e79a46"),
                            LaptopId = new Guid("0b27d46f-4301-4f3f-b480-383f1b297bee")
                        });
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("654b7573-9501-436a-ad36-94c5696ac28f"),
                            Name = "Dell",
                            Price = 135.11m
                        },
                        new
                        {
                            Id = new Guid("0d9ffad1-0149-432b-b94d-3442707160db"),
                            Name = "Toshiba",
                            Price = 135.11m
                        },
                        new
                        {
                            Id = new Guid("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"),
                            Name = "HP",
                            Price = 135.11m
                        },
                        new
                        {
                            Id = new Guid("c2e1bb5f-6e45-4881-8d75-c3d6d18358fb"),
                            Name = "Apple",
                            Price = 135.11m
                        });
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("LaptopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LaptopId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Configuration", b =>
                {
                    b.HasOne("LapTopShop.Models.DataModels.ConfigurationType", "ConfigurationType")
                        .WithMany("Configurations")
                        .HasForeignKey("ConfigurationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConfigurationType");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Laptop", b =>
                {
                    b.HasOne("LapTopShop.Models.DataModels.Manufacturer", "Manufacturer")
                        .WithMany("Laptops")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.LaptopConfiguration", b =>
                {
                    b.HasOne("LapTopShop.Models.DataModels.Configuration", "Configuration")
                        .WithMany("Laptops")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LapTopShop.Models.DataModels.Laptop", "Laptop")
                        .WithMany("LaptopConfigurations")
                        .HasForeignKey("LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Configuration");

                    b.Navigation("Laptop");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Order", b =>
                {
                    b.HasOne("LapTopShop.Models.DataModels.Laptop", "Laptop")
                        .WithMany("Orders")
                        .HasForeignKey("LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Configuration", b =>
                {
                    b.Navigation("Laptops");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.ConfigurationType", b =>
                {
                    b.Navigation("Configurations");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Laptop", b =>
                {
                    b.Navigation("LaptopConfigurations");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("LapTopShop.Models.DataModels.Manufacturer", b =>
                {
                    b.Navigation("Laptops");
                });
#pragma warning restore 612, 618
        }
    }
}
