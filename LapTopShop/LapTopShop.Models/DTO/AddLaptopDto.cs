using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LapTopShop.Models.DTO
{
    public class AddLaptopDto
    {
        [Required]
        public Guid ManufacturerId { get; set; }

        [Required]
        public List<Guid> Configurations { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
