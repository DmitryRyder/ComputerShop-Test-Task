using System;
using System.Linq;
using System.Threading.Tasks;
using LapTopShop.DAL.Contexts;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LapTopShop.DAL.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LapTopDataBaseContext _context;

        public OrderRepository(LapTopDataBaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create order.
        /// </summary>
        public async Task<Order> AddAsync(Order model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(Order));
            }

            var addedOrder = new Order()
            {
                CustomerEmail = model.CustomerEmail,
                LaptopId = model.LaptopId,
            };

            _context.Orders.Add(addedOrder);

            await _context.SaveChangesAsync();

            var result = await _context.Orders
                .Include(l => l.Laptop)
                    .ThenInclude(l => l.LaptopConfigurations)
                          .ThenInclude(l => l.Configuration)
                    .Include(l => l.Laptop)
                        .ThenInclude(l => l.Manufacturer)
                    .Where(l => l.Id == addedOrder.Id)
                    .FirstOrDefaultAsync();

            return result;
        }
    }
}
