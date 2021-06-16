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
    public class LaptopControllerTest
    {
        private readonly IMediator _mediator;
        private readonly LaptopController _testee;
        private readonly AddLaptopDto _addLaptopDto;
        private readonly Guid _id = Guid.Parse("5224ed94-6d9c-42ec-ba93-dfb11fe68931");

        public LaptopControllerTest()
        {
            var mapper = A.Fake<IMapper>();
            _mediator = A.Fake<IMediator>();
            _testee = new LaptopController(mapper, _mediator);

            _addLaptopDto = new AddLaptopDto
            {
                ManufacturerId = _id,
                Name = "TestLaptop"
            };

            var laptops = new List<Laptop>
            {
                new Laptop
                {
                    Id = Guid.Parse("5224ed94-6d9c-42ec-ba93-dfb11fe68441"),
                    ManufacturerId = Guid.Parse("7962d749-1bcc-467b-af58-afbbfcf1cf1b"),
                    Name = "TestNameOfLaptop1",
                    Price = 2123.145m
                },
                new Laptop
                {
                    Id = Guid.Parse("e8dc0805-89e2-4e78-9519-ed2c17df9161"),
                    ManufacturerId = Guid.Parse("214cba5d-f42d-41da-b860-b8d66d4d5be8"),
                    Name = "TestNameOfLaptop2",
                    Price = 21323.45m
                },
                new Laptop
                {
                    Id = Guid.Parse("241c0e65-8546-48f0-bf3b-cbec0a417abb"),
                    ManufacturerId = Guid.Parse("76e53d77-1f0f-4e63-96ba-1a51a498b82a"),
                    Name = "TestNameOfLaptop3",
                    Price = 3453.45m
                }
            };

            var laptopsDto = new List<GetLaptopDto>
            {
                new GetLaptopDto
                {
                    Id = Guid.Parse("5224ed94-6d9c-42ec-ba93-dfb11fe68441"),
                    Name = "TestNameOfLaptop1",
                    Price = 2123.145m
                },
                new GetLaptopDto
                {
                    Id = Guid.Parse("e8dc0805-89e2-4e78-9519-ed2c17df9161"),
                    Name = "TestNameOfLaptop2",
                    Price = 21323.45m
                },
                new GetLaptopDto
                {
                    Id = Guid.Parse("241c0e65-8546-48f0-bf3b-cbec0a417abb"),
                    Name = "TestNameOfLaptop3",
                    Price = 3453.45m
                }
            };

            A.CallTo(() => mapper.Map<List<Laptop>, List<GetLaptopDto>>(A<List<Laptop>>._)).Returns(laptopsDto);
            A.CallTo(() => mapper.Map<GetLaptopDto>(A<Laptop>._)).Returns(laptopsDto.First());
            A.CallTo(() => _mediator.Send(A<CreateLaptopCommand>._, default)).Returns(laptops.First());
            A.CallTo(() => _mediator.Send(A<GetLaptopsQuery>._, default)).Returns(laptops);
        }

        [Theory]
        [InlineData("CreateLaptopAsync: laptop is null")]
        public async void Post_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreateLaptopCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _testee.Laptop(_addLaptopDto);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Get_ShouldReturnLaptops()
        {
            var result = await _testee.Laptops();

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<List<GetLaptopDto>>();
            result.Value.Count.Should().Be(3);
        }

        [Theory]
        [InlineData("Laptop could not be loaded")]
        public async void Get_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<GetLaptopsQuery>._, default)).Throws(new Exception(exceptionMessage));

            var result = await _testee.Laptops();

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Post_ShouldReturnLaptop()
        {
            var result = await _testee.Laptop(_addLaptopDto);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<GetLaptopDto>();
            result.Value.Name.Should().Be("TestNameOfLaptop1");
            result.Value.Id.Should().Be("5224ed94-6d9c-42ec-ba93-dfb11fe68441");
        }
    }
}
