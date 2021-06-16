using System;

namespace LapTopShop.Models.DTO
{
    public class GetConfigurationDto
    {
        public Guid Id { get; set; }

        public string TypeName { get; set; }

        public string Value { get; set; }

        public decimal Price { get; set; }
    }
}
