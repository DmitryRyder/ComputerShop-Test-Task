using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapTopShop.Models.DataModels
{
    public class Manufacturer
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Price { get; set; }
        public virtual List<Laptop> Laptops { get; set; }
    }
}
