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
    public class CreateConfigurationCommandHandlerTests
    {
        private readonly CreateConfigurationCommandHandler _testee;
        private readonly IConfigurationRepository _configurationRepository;

        public CreateConfigurationCommandHandlerTests()
        {
            _configurationRepository = A.Fake<IConfigurationRepository>();
            _testee = new CreateConfigurationCommandHandler(_configurationRepository);
        }

        [Fact]
        public async void Handle_ShouldCallAddAsync()
        {
            await _testee.Handle(new CreateConfigurationCommand(), default);

            A.CallTo(() => _configurationRepository.AddAsync(A<Configuration>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Handle_ShouldReturnCreatedConfiguration()
        {
            A.CallTo(() => _configurationRepository.AddAsync(A<Configuration>._)).Returns(new Configuration
            {
                Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                Value = "TestName",
                Price = 135.11m
            });

            var result = await _testee.Handle(new CreateConfigurationCommand(), default);

            result.Should().BeOfType<Configuration>();
            result.Value.Should().Be("TestName");
            result.Price.Should().Be(135.11m);
            result.Id.Should().Be("654b7573-9501-436a-ad36-94c5696ac28f");
        }
    }
}
