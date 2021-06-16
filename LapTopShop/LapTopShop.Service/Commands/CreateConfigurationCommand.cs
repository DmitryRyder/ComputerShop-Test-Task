using LapTopShop.Models.DataModels;
using MediatR;

namespace LapTopShop.Service.Commands
{
    public class CreateConfigurationCommand : IRequest<Configuration>
    {
        public Configuration Configuration { get; set; }
    }
}
