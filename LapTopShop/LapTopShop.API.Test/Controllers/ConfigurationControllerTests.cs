using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using LapTopShop.API.Controllers;
using LapTopShop.Models.DataModels;
using LapTopShop.Models.DTO;
using LapTopShop.Service.Commands;
using LapTopShop.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace LapTopShop.API.Test.Controllers
{
    public class ConfigurationControllerTests
    {
        private readonly IMediator _mediator;
        private readonly ConfigurationController _testee;
        private readonly AddConfigurationDto _addConfigurationDto;
        private readonly Guid _id = Guid.Parse("5224ed94-6d9c-42ec-ba93-dfb11fe68931");

        public ConfigurationControllerTests()
        {
            var mapper = A.Fake<IMapper>();
            _mediator = A.Fake<IMediator>();
            _testee = new ConfigurationController(mapper, _mediator);
            _addConfigurationDto = new AddConfigurationDto
            {
                ConfigurationTypeId = _id,
                Price = 213.13m,
                Value = "TestConfiguration"
            };

            var configurations = new List<Configuration>
            {
                new Configuration
                {
                    Id = _id,
                    Price = 213.13m,
                    ConfigurationTypeId = Guid.Parse("5224ed94-6d9c-42ec-ba93-dfb11fe68441"),
                    Value = "TestConfigurationValue1"
                },
                new Configuration
                {
                    Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    Price = 21323.33m,
                    ConfigurationTypeId = Guid.Parse("054b7573-1501-436a-ad36-94c5696ac28f"),
                    Value = "TestConfigurationValue2"
                }
            };

            var configurationTypes = new List<GetConfigurationDto>
            {
                new GetConfigurationDto
                {
                    Id = _id,
                    Price = 21323.33m,
                    TypeName = "TestConfigurationType1",
                    Value = "TestValueType1"
                },
                new GetConfigurationDto
                {
                    Id = Guid.Parse("5af14d60-a50b-4730-a6ee-8c78267a36fc"),
                    Price = 71623.33m,
                    TypeName = "TestConfigurationType2",
                    Value = "TestValueType2"
                },
                new GetConfigurationDto
                {
                    Id = Guid.Parse("54ba01bc-2252-49b3-a1d0-44d09d6df5be"),
                    Price = 22623.33m,
                    TypeName = "TestConfigurationType3",
                    Value = "TestValueType3"
                }
            };

            A.CallTo(() => mapper.Map<List<Configuration>, List<GetConfigurationDto>>(A<List<Configuration>>._)).Returns(configurationTypes);
            A.CallTo(() => mapper.Map<GetConfigurationDto>(A<Configuration>._)).Returns(configurationTypes.First());
            A.CallTo(() => _mediator.Send(A<CreateConfigurationCommand>._, default)).Returns(configurations.First());
            A.CallTo(() => _mediator.Send(A<GetConfigurationsQuery>._, default)).Returns(configurations);
        }

        [Theory]
        [InlineData("CreateConfigurationAsync: configuration is null")]
        public async void Post_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreateConfigurationCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _testee.Configuration(_addConfigurationDto);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Get_ShouldReturnConfigurationTypes()
        {
            var result = await _testee.Configurations();

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<List<GetConfigurationDto>>();
            result.Value.Count.Should().Be(3);
        }

        [Theory]
        [InlineData("Configuration could not be loaded")]
        public async void Get_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<GetConfigurationsQuery>._, default)).Throws(new Exception(exceptionMessage));

            var result = await _testee.Configurations();

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Post_ShouldReturnConfiguration()
        {
            var result = await _testee.Configuration(_addConfigurationDto);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<GetConfigurationDto>();
            result.Value.Id.Should().Be(_id);
        }
    }
}
