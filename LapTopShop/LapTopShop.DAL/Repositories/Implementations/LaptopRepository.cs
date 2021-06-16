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
    public class LaptopRepository : ILaptopRepository
    {
        private readonly LapTopDataBaseContext _context;

        public LaptopRepository(LapTopDataBaseContext context)
        {
            _context = context;
        }

        public async Task<Laptop> AddAsync(Laptop model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(Laptop));
            }

            if (model.LaptopConfigurations != null && model.LaptopConfigurations.Any())
            {
                var existingListOfConfigurations = model.LaptopConfigurations.Select(i => i.ConfigurationId).ToList();
                var existingLaptops = from currentConfigs in existingListOfConfigurations
                                      join existingConfigs in _context.LaptopConfigurations on currentConfigs equals existingConfigs.ConfigurationId
                                      group new { currentConfigs, existingConfigs } by existingConfigs.LaptopId into groupedConfigs
                                      let laptopId = groupedConfigs.Key
                                      let configCount = groupedConfigs.Count(l => l.existingConfigs != null)
                                      let totalCount = groupedConfigs.Count()
                                      where configCount == existingListOfConfigurations.Count && configCount == totalCount
                                      select laptopId;

                if ((bool)existingLaptops?.Any())
                {
                    throw new ArgumentException($"Laptop(s) with the same configurations is(are) already exists! Id(s): [{string.Join(',', existingLaptops)}]");
                }
            }

            var addedlaptop = new Laptop()
                {
                    Name = model.Name,
                    ManufacturerId = model.ManufacturerId,
                };
            _context.Laptops.Add(addedlaptop);

            await _context.SaveChangesAsync();

            if (model.LaptopConfigurations != null && model.LaptopConfigurations.Any())
            {
                _context.LaptopConfigurations.AddRange(model.LaptopConfigurations
                .Select(c => new LaptopConfiguration
                {
                    LaptopId = addedlaptop.Id,
                    ConfigurationId = c.ConfigurationId,
                }));

                await _context.SaveChangesAsync();
            }

            var result = await _context.Laptops
                .Include(l => l.Manufacturer)
                .Include(l => l.LaptopConfigurations)
                    .ThenInclude(l => l.Configuration)
                    .ThenInclude(l => l.ConfigurationType)
                    .Where(l => l.Id == addedlaptop.Id)
                    .FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Laptop>> GetListAsync()
        {
            return await _context.Laptops
                    .Include(l => l.Manufacturer)
                    .Include(l => l.LaptopConfigurations)
                        .ThenInclude(l => l.Configuration)
                        .ThenInclude(l => l.ConfigurationType)
                    .ToListAsync();
        }

        public async Task<Laptop> GetByIdAsync(Guid id)
        {
            return await _context.Laptops
                    .Include(l => l.Manufacturer)
                    .Include(l => l.LaptopConfigurations)
                        .ThenInclude(l => l.Configuration)
                        .ThenInclude(l => l.ConfigurationType)
                    .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
