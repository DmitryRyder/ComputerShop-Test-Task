using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LapTopShop.DAL.Contexts;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LapTopShop.DAL.Repositories.Implementations
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly LapTopDataBaseContext _context;

        public ConfigurationRepository(LapTopDataBaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of configurations.
        /// </summary>
        public async Task<List<Configuration>> GetListAsync()
        {
            return await _context.Configurations
             .Include(c => c.ConfigurationType)
             .ToListAsync();
        }

        public async Task<Configuration> AddAsync(Configuration model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(Configuration));
            }

            var toAddConfig = new Configuration()
            {
                ConfigurationTypeId = model.ConfigurationTypeId,
                Price = model.Price,
                Value = model.Value,
            };

            _context.Configurations.Add(toAddConfig);
            await _context.SaveChangesAsync();

            var result = await _context.Configurations
                .Include(l => l.ConfigurationType)
                    .Where(l => l.Id == toAddConfig.Id)
                    .FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Get list of configuration types.
        /// </summary>
        public async Task<List<ConfigurationType>> GetTypeListAsync()
        {
            return await _context.ConfigurationTypes.ToListAsync();
        }
    }
}
