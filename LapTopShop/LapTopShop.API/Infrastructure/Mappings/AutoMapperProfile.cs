using AutoMapper;
using LapTopShop.Models.DataModels;
using LapTopShop.Models.DTO;
using System.Linq;

namespace LapTopShop.API.Infrastructure.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddLaptopDto, Laptop>().ForMember(x => x.Id, opt => opt.Ignore())
                                             .ForMember(x => x.LaptopConfigurations, opt => opt.MapFrom(i => i.Configurations.Select(o => new LaptopConfiguration { ConfigurationId = o })))
                                             .ForMember(x => x.Manufacturer, opt => opt.MapFrom(i => new Manufacturer { Id = i.ManufacturerId }));

            CreateMap<Laptop, GetLaptopDto>().ForMember(x => x.LaptopConfigurations, opt => opt.MapFrom(i => i.LaptopConfigurations.Select(o => new GetConfigurationDto { Id = o.Id, TypeName = o.Configuration.ConfigurationType.Name, Value = o.Configuration.Value })))
                                             .ForMember(x => x.Manufacturer, opt => opt.MapFrom(i => new GetManufacturerDto { Id = i.ManufacturerId, Name = i.Manufacturer.Name }))
                                             .ForMember(x => x.Price, opt => opt.MapFrom(i => i.LaptopConfigurations.Sum(o => o.Configuration.Price) + i.Manufacturer.Price));

            CreateMap<AddConfigurationDto, Configuration>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Configuration, GetConfigurationDto>().ForMember(x => x.TypeName, opt => opt.MapFrom(i => i.ConfigurationType.Name));
            CreateMap<ConfigurationType, GetConfigurationTypeDto>();
            CreateMap<AddOrderDto, Order>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Order, GetOrderDto>();/*.ForPath(x => x.Laptop.Price, opt => opt.MapFrom(i => i.Laptop.LaptopConfigurations.Sum(o => o.Configuration.Price) + i.Laptop.Manufacturer.Price));*/
        }
    }
}
