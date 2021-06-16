using System;
using System.ComponentModel.DataAnnotations;

namespace LapTopShop.Models.DTO
{
    public class AddConfigurationDto
    {
        [Required]
        public Guid ConfigurationTypeId { get; set; }
     
        [Required]
        public string Value { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
