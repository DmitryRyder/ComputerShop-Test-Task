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
    public class CreateLaptopCommandHandlerTests
    {
        private readonly CreateLaptopCommandHandler _testee;
        private readonly ILaptopRepository _laptopRepository;

        public CreateLaptopCommandHandlerTests()
        {
            _laptopRepository = A.Fake<ILaptopRepository>();
            _testee = new CreateLaptopCommandHandler(_laptopRepository);
        }

        [Fact]
        public async void Handle_ShouldCallAddAsync()
        {
            await _testee.Handle(new CreateLaptopCommand(), default);

            A.CallTo(() => _laptopRepository.AddAsync(A<Laptop>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedLaptop()
        {
            A.CallTo(() => _laptopRepository.AddAsync(A<Laptop>._)).Returns(new Laptop
            {
                Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                Name = "testModelName",
                Price = 123.24m,
                ManufacturerId = Guid.Parse("654b7573-9501-116a-ad36-94c5696ac28f")
            });

            var result = await _testee.Handle(new CreateLaptopCommand(), default);

            result.Should().BeOfType<Laptop>();
            result.Id.Should().Be("654b7573-9501-436a-ad36-94c5696ac28f");
            result.Price.Should().Be(123.24m);
            result.Name.Should().Be("testModelName");
            result.ManufacturerId.Should().Be("654b7573-9501-116a-ad36-94c5696ac28f");
        }
    }
}
