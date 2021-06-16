using System;
using System.Threading;
using System.Threading.Tasks;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.Commands;
using MediatR;

namespace LapTopShop.Service.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(ILaptopRepository laptopRepository, IOrderRepository orderRepository)
        {
            _laptopRepository = laptopRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var existedLaptopId = await _laptopRepository.GetByIdAsync(request.Order.LaptopId);
            if (existedLaptopId == null)
            {
                throw new ArgumentNullException($"Laptop with provided id [{existedLaptopId}] cannot be found!");
            }

            return await _orderRepository.AddAsync(request.Order);
        }
    }
}
