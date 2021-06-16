using LapTopShop.Models.DataModels;
using MediatR;

namespace LapTopShop.Service.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
