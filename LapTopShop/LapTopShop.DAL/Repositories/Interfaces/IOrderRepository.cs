using LapTopShop.Models.DataModels;
using System.Threading.Tasks;

namespace LapTopShop.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order model);
    }
}
