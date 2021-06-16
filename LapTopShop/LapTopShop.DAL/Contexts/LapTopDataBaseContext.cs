using System;
using LapTopShop.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LapTopShop.DAL.Contexts
{
    public class LapTopDataBaseContext : DbContext
    {
        public LapTopDataBaseContext()
        {
        }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<ConfigurationType> ConfigurationTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<LaptopConfiguration> LaptopConfigurations { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public LapTopDataBaseContext(DbContextOptions<LapTopDataBaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var manufactures = new[]
            {
                new Manufacturer
                {
                    Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    Name = "Dell",
                    Price = 135.11m
                },
                new Manufacturer
                {
                    Id = Guid.Parse("0d9ffad1-0149-432b-b94d-3442707160db"),
                    Name = "Toshiba",
                    Price = 135.11m
                },
                new Manufacturer
                {
                    Id = Guid.Parse("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"),
                    Name = "HP",
                    Price = 135.11m
                },
                new Manufacturer
                {
                    Id = Guid.Parse("c2e1bb5f-6e45-4881-8d75-c3d6d18358fb"),
                    Name = "Apple",
                    Price = 135.11m
                },
            };

            var configurationtypes = new[]
            {
                new ConfigurationType
                {
                    Id = Guid.Parse("c6536d6b-e9eb-4f60-a0da-66937e1ea5dd"),
                    Name = "Ram"
                },
                new ConfigurationType
                {
                    Id = Guid.Parse("4ebe08ef-e10e-4443-946a-8c19da907998"),
                    Name = "HDD"
                },
                new ConfigurationType
                {
                    Id = Guid.Parse("503d743b-c33d-4789-bfa6-608f512f744a"),
                    Name = "Colour"
                },
                new ConfigurationType
                {
                    Id = Guid.Parse("7a14a4fe-caeb-42cf-a31f-96952636e155"),
                    Name = "Processor"
                }
            };

            var configurations = new[]
            {
                new Configuration
                {
                    Id = Guid.Parse("413e3ddc-7064-404b-8fa5-41f664473177"),
                    Price = 535.21m,
                    ConfigurationTypeId = Guid.Parse("c6536d6b-e9eb-4f60-a0da-66937e1ea5dd"),
                    Value = "8 GB"
                },
                new Configuration
                {
                    Id = Guid.Parse("269ed5d8-1273-441b-8839-35f20bb54508"),
                    Price = 635.21m,
                    ConfigurationTypeId = Guid.Parse("4ebe08ef-e10e-4443-946a-8c19da907998"),
                    Value = "16 GB"
                },
                new Configuration
                {
                    Id = Guid.Parse("ffbe392e-8812-4831-96c5-dc97b6e79a46"),
                    Price = 535.21m,
                    ConfigurationTypeId = Guid.Parse("4ebe08ef-e10e-4443-946a-8c19da907998"),
                    Value = "500 GB"
                },
                new Configuration
                {
                    Id = Guid.Parse("1ad30101-f986-4a53-a11a-db359da3b15e"),
                    Price = 535.21m,
                    ConfigurationTypeId = Guid.Parse("4ebe08ef-e10e-4443-946a-8c19da907998"),
                    Value = "1 TB"
                },
                new Configuration
                {
                    Id = Guid.Parse("40f89c10-366e-44b7-b836-130d7ac1471b"),
                    Price = 535.21m,
                    ConfigurationTypeId = Guid.Parse("503d743b-c33d-4789-bfa6-608f512f744a"),
                    Value = "8 GB"
                },
                new Configuration
                {
                    Id = Guid.Parse("02c447bc-5093-443e-926a-ead26ef9c92e"),
                    Price = 535.21m,
                    ConfigurationTypeId = Guid.Parse("503d743b-c33d-4789-bfa6-608f512f744a"),
                    Value = "Red"
                },
                new Configuration
                {
                    Id = Guid.Parse("c96284ed-2a78-41d6-b888-b437475b774b"),
                    Price = 535.21m,
                    ConfigurationTypeId = Guid.Parse("503d743b-c33d-4789-bfa6-608f512f744a"),
                    Value = "Blue"
                }
            };

            var lapTops = new[]
            {
                new Laptop
                {
                    Id = Guid.Parse("6307149d-74e1-4baf-8b59-a98895217f65"),
                    Name = "Bysiness laptop",
                    ManufacturerId = Guid.Parse("0d9ffad1-0149-432b-b94d-3442707160db"),
                },
                new Laptop
                {
                    Id = Guid.Parse("27ce6a5a-8036-41d8-b4a3-24386fb7c971"),
                    Name = "Gaming laptop",
                    ManufacturerId = Guid.Parse("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"),
                },
                new Laptop
                {
                    Id = Guid.Parse("0b27d46f-4301-4f3f-b480-383f1b297bee"),
                    Name = "Lite laptop",
                    ManufacturerId = Guid.Parse("9c32d6f4-b527-4839-ba4f-1d1b9740dd4b"),
                }
            };

            var lapTopConfigurations = new[]
{
                new LaptopConfiguration
                {
                    Id = Guid.Parse("fb000c38-19b8-445d-b23f-be079732af99"),
                    ConfigurationId = Guid.Parse("413e3ddc-7064-404b-8fa5-41f664473177"),
                    LaptopId = Guid.Parse("6307149d-74e1-4baf-8b59-a98895217f65")
                },
                new LaptopConfiguration
                {
                    Id = Guid.Parse("f625cf2b-961e-4031-9615-f4b198864957"),
                    ConfigurationId = Guid.Parse("269ed5d8-1273-441b-8839-35f20bb54508"),
                    LaptopId = Guid.Parse("27ce6a5a-8036-41d8-b4a3-24386fb7c971")
                },
                new LaptopConfiguration
                {
                    Id = Guid.Parse("45703ceb-c89d-4abb-80a5-d1a5b8a11288"),
                    ConfigurationId = Guid.Parse("ffbe392e-8812-4831-96c5-dc97b6e79a46"),
                    LaptopId = Guid.Parse("0b27d46f-4301-4f3f-b480-383f1b297bee")
                }
            };

            modelBuilder.Entity<LaptopConfiguration>()
                .HasOne(l => l.Laptop)
                .WithMany(c => c.LaptopConfigurations)
                .HasForeignKey(c => c.LaptopId);

            modelBuilder.Entity<LaptopConfiguration>()
                .HasOne(l => l.Configuration)
                .WithMany(o => o.Laptops)
                .HasForeignKey(l => l.ConfigurationId);

            modelBuilder.Entity<ConfigurationType>()
                .HasData(configurationtypes);

            modelBuilder.Entity<Configuration>()
                .HasOne(l => l.ConfigurationType)
                .WithMany(o => o.Configurations)
                .HasForeignKey(l => l.ConfigurationTypeId);

            modelBuilder.Entity<Configuration>()
                .HasData(configurations);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Laptop)
                .WithMany(l => l.Orders);

            modelBuilder.Entity<Laptop>()
                .HasOne(o => o.Manufacturer)
                .WithMany(l => l.Laptops)
                .HasForeignKey(l => l.ManufacturerId);

            modelBuilder.Entity<Manufacturer>()
                .HasData(manufactures);

            modelBuilder.Entity<Laptop>()
                .HasData(lapTops);

            modelBuilder.Entity<LaptopConfiguration>()
                .HasData(lapTopConfigurations);
        }
    }
}
