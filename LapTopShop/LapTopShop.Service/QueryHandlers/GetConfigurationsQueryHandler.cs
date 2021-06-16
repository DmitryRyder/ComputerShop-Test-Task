using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.Queries;
using MediatR;

namespace LapTopShop.Service.QueryHandlers
{
    public class GetConfigurationsQueryHandler : IRequestHandler<GetConfigurationsQuery, List<Configuration>>
    {
        private readonly IConfigurationRepository _configurationRepository;

        public GetConfigurationsQueryHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<List<Configuration>> Handle(GetConfigurationsQuery request, CancellationToken cancellationToken)
        {
            return await _configurationRepository.GetListAsync();
        }
    }
}
