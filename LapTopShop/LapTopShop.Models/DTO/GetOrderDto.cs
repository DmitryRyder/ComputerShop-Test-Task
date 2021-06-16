using System;

namespace LapTopShop.Models.DTO
{
    public class GetOrderDto
    {
        public Guid Id { get; set; }

        public string CustomerEmail { get; set; }

        public GetLaptopDto Laptop { get; set; }
    }
}
