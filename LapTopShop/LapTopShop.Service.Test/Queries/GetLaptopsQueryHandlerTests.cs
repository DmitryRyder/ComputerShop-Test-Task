using FakeItEasy;
using FluentAssertions;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.Queries;
using LapTopShop.Service.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace LapTopShop.Service.Test.Queries
{
    public class GetLaptopsQueryHandlerTests
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly GetLaptopsQueryHandler _testee;
        private readonly List<Laptop> _laptops;

        public GetLaptopsQueryHandlerTests()
        {
            _laptopRepository = A.Fake<ILaptopRepository>();
            _testee = new GetLaptopsQueryHandler(_laptopRepository);

            _laptops = new List<Laptop>
            {
                new Laptop
                {
                    Id = new Guid(),
                    Name = "TestName1",
                    Price = 20043.21m
                },
                new Laptop
                {
                    Id = new Guid(),
                    Name = "TestName2",
                    Price = 21043.21m
                },
                new Laptop
                {
                    Id = new Guid(),
                    Name = "TestName3",
                    Price = 29943.99m
                }
            };
        }

        [Fact]
        public async Task Handle_ShouldReturnConfigurationTypes()
        {
            A.CallTo(() => _laptopRepository.GetListAsync()).Returns(_laptops);

            var result = await _testee.Handle(new GetLaptopsQuery(), default);

            A.CallTo(() => _laptopRepository.GetListAsync()).MustHaveHappenedOnceExactly();
            result.Should().BeOfType<List<Laptop>>();
            result.Count.Should().Be(3);
        }
    }
}
