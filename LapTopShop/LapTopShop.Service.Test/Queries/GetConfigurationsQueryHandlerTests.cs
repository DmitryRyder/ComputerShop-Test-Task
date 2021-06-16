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
    public class GetConfigurationsQueryHandlerTests
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly GetConfigurationsQueryHandler _testee;
        private readonly List<Configuration> _configurations;

        public GetConfigurationsQueryHandlerTests()
        {
            _configurationRepository = A.Fake<IConfigurationRepository>();
            _testee = new GetConfigurationsQueryHandler(_configurationRepository);

            _configurations = new List<Configuration>
            {
                new Configuration
                {
                    Id = new Guid(),
                    Price = 213.33m,
                    Value = "TestValue1"
                },
                new Configuration
                {
                    Id = new Guid(),
                    Price = 25432.33m,
                    Value = "TestValue2"
                }
            };
        }

        [Fact]
        public async Task Handle_ShouldReturnConfigurations()
        {
            A.CallTo(() => _configurationRepository.GetListAsync()).Returns(_configurations);

            var result = await _testee.Handle(new GetConfigurationsQuery(), default);

            A.CallTo(() => _configurationRepository.GetListAsync()).MustHaveHappenedOnceExactly();
            result.Should().BeOfType<List<Configuration>>();
            result.Count.Should().Be(2);
        }
    }
}
