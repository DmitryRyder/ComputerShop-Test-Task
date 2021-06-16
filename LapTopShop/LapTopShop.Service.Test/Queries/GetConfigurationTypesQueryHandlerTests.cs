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
    public class GetConfigurationTypesQueryHandlerTests
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly GetConfigurationTypesQueryHandler _testee;
        private readonly List<ConfigurationType> _configurationTypes;

        public GetConfigurationTypesQueryHandlerTests()
        {
            _configurationRepository = A.Fake<IConfigurationRepository>();
            _testee = new GetConfigurationTypesQueryHandler(_configurationRepository);

            _configurationTypes = new List<ConfigurationType>
            {
                new ConfigurationType
                {
                    Id = new Guid(),
                    Name = "TestName1"
                },
                new ConfigurationType
                {
                    Id = new Guid(),
                    Name = "TestName2"
                }
            };
        }

        [Fact]
        public async Task Handle_ShouldReturnConfigurationTypes()
        {
            A.CallTo(() => _configurationRepository.GetTypeListAsync()).Returns(_configurationTypes);

            var result = await _testee.Handle(new GetConfigurationTypesQuery(), default);

            A.CallTo(() => _configurationRepository.GetTypeListAsync()).MustHaveHappenedOnceExactly();
            result.Should().BeOfType<List<ConfigurationType>>();
            result.Count.Should().Be(2);
        }
    }
}
