using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTopShop.Models.DataModels
{
    public class Configuration
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ConfigurationTypeId { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; set; }

        public virtual ConfigurationType ConfigurationType { get; set; }

        public virtual List<LaptopConfiguration> Laptops { get; set; }
    }
}
