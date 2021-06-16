using System.Collections.Generic;
using LapTopShop.Models.DataModels;
using MediatR;

namespace LapTopShop.Service.Queries
{
    public class GetConfigurationTypesQuery : IRequest<List<ConfigurationType>>
    {
    }
}
