using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.Queries;
using MediatR;

namespace LapTopShop.Service.QueryHandlers
{
    public class GetConfigurationTypesQueryHandler : IRequestHandler<GetConfigurationTypesQuery, List<ConfigurationType>>
    {
        private readonly IConfigurationRepository _configurationRepository;

        public GetConfigurationTypesQueryHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<List<ConfigurationType>> Handle(GetConfigurationTypesQuery request, CancellationToken cancellationToken)
        {
            return await _configurationRepository.GetTypeListAsync();
        }
    }
}
