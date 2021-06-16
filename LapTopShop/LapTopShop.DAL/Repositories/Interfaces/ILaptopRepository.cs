using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LapTopShop.Models.DataModels;

namespace LapTopShop.DAL.Repositories.Interfaces
{
    public interface ILaptopRepository
    {
        /// <summary>
        /// Get list of laptops.
        /// </summary>
        Task<List<Laptop>> GetListAsync();

        /// <summary>
        /// Add a new laptop.
        /// </summary>
        Task<Laptop> AddAsync(Laptop model);

        Task<Laptop> GetByIdAsync(Guid id);
    }
}
