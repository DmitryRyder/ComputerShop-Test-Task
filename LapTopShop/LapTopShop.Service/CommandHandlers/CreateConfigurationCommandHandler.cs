using System.Threading;
using System.Threading.Tasks;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.Commands;
using MediatR;

namespace LapTopShop.Service.CommandHandlers
{
    public class CreateConfigurationCommandHandler : IRequestHandler<CreateConfigurationCommand, Configuration>
    {
        private readonly IConfigurationRepository _configurationRepository;

        public CreateConfigurationCommandHandler(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<Configuration> Handle(CreateConfigurationCommand request, CancellationToken cancellationToken)
        {
            return await _configurationRepository.AddAsync(request.Configuration);
        }
    }
}
