using FakeItEasy;
using FluentAssertions;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.CommandHandlers;
using LapTopShop.Service.Commands;
using System;
using Xunit;
namespace LapTopShop.Service.Test.Commands
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly CreateOrderCommandHandler _testee;
        private readonly ILaptopRepository _laptopRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandlerTests()
        {
            _laptopRepository = A.Fake<ILaptopRepository>();
            _orderRepository = A.Fake<IOrderRepository>();
            _testee = new CreateOrderCommandHandler(_laptopRepository, _orderRepository);
        }

        [Fact]
        public async void Handle_ShouldCallAddAsync()
        {
            await _testee.Handle(new CreateOrderCommand { Order = new Order { LaptopId = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f") } }, default);

            A.CallTo(() => _laptopRepository.GetByIdAsync(A<Guid>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _orderRepository.AddAsync(A<Order>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedOrder()
        {
            A.CallTo(() => _laptopRepository.GetByIdAsync(A<Guid>._)).Returns(new Laptop
            {
                Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                Name = "testModelName",
                Price = 123.24m,
                ManufacturerId = Guid.Parse("654b7573-9501-116a-ad36-94c5696ac28f")
            });

            A.CallTo(() => _orderRepository.AddAsync(A<Order>._)).Returns(new Order
            {
                Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                LaptopId = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f")
            });

            var result = await _testee.Handle(new CreateOrderCommand { Order = new Order { LaptopId = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f") } }, default);

            result.Should().BeOfType<Order>();
            result.Id.Should().Be("654b7573-9501-436a-ad36-94c5696ac28f");
            result.LaptopId.Should().Be("654b7573-9501-436a-ad36-94c5696ac28f");
        }
    }
}
