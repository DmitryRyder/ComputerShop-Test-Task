using System.Collections.Generic;
using System.Threading.Tasks;
using LapTopShop.Models.DataModels;

namespace LapTopShop.DAL.Repositories.Interfaces
{
    public interface IConfigurationRepository
    {
        /// <summary>
        /// Get list of congigurations.
        /// </summary>
        Task<List<Configuration>> GetListAsync();

        /// <summary>
        /// Add a new configuration.
        /// </summary>
        Task<Configuration> AddAsync(Configuration model);

        /// <summary>
        /// Add a new laptop.
        /// </summary>
        Task<List<ConfigurationType>> GetTypeListAsync();
    }
}
