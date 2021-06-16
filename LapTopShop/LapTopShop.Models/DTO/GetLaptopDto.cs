using System;
using System.Collections.Generic;

namespace LapTopShop.Models.DTO
{
    public class GetLaptopDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<GetConfigurationDto> LaptopConfigurations { get; set; }

        public GetManufacturerDto Manufacturer { get; set; }
    }
}
