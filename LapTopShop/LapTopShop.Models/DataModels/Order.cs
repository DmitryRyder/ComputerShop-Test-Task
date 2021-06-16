using System;
using System.ComponentModel.DataAnnotations;

namespace LapTopShop.Models.DataModels
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string CustomerEmail { get; set; }

        public Guid LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
