using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTopShop.Models.DataModels
{
    public class Laptop
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ManufacturerId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; set; }

        public virtual List<LaptopConfiguration> LaptopConfigurations { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
