using System;
using System.ComponentModel.DataAnnotations;

namespace LapTopShop.Models.DTO
{
    public class AddOrderDto
    {
        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public Guid LaptopId { get; set; }
    }
}
