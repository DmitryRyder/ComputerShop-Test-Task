using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using LapTopShop.API.Controllers;
using LapTopShop.Models.DataModels;
using LapTopShop.Models.DTO;
using LapTopShop.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Xunit;

namespace LapTopShop.API.Test.Controllers
{
    public class OrderControllerTests
    {
        private readonly IMediator _mediator;
        private readonly OrderController _testee;
        private readonly AddOrderDto _addOrderDto;
        private readonly Guid _id = Guid.Parse("5224ed94-6d9c-42ec-ba93-dfb11fe68931");

        public OrderControllerTests()
        {
            var mapper = A.Fake<IMapper>();
            _mediator = A.Fake<IMediator>();
            _testee = new OrderController(mapper, _mediator);

            _addOrderDto = new AddOrderDto
            {
                CustomerEmail = "test@mail.com",
                LaptopId = _id
            };

            var getOrderDto = new GetOrderDto
            {
                Id = _id,
                CustomerEmail = "test@mail.com"
            };

            var order = new Order
            {
                Id = _id,
                CustomerEmail = "test@mail.com",
                LaptopId = Guid.Parse("241c0e65-8546-48f0-bf3b-cbec0a417abb")
            };

            A.CallTo(() => mapper.Map<GetOrderDto>(A<Order>._)).Returns(getOrderDto);
            A.CallTo(() => _mediator.Send(A<CreateOrderCommand>._, default)).Returns(order);
        }

        [Theory]
        [InlineData("CreateLaptopAsync: laptop is null")]
        public async void Post_WhenAnExceptionOccurs_ShouldReturnBadRequest(string exceptionMessage)
        {
            A.CallTo(() => _mediator.Send(A<CreateOrderCommand>._, default)).Throws(new ArgumentException(exceptionMessage));

            var result = await _testee.Laptop(_addOrderDto);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(exceptionMessage);
        }

        [Fact]
        public async void Post_ShouldReturnOrder()
        {
            var result = await _testee.Laptop(_addOrderDto);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<GetOrderDto>();
            result.Value.CustomerEmail.Should().Be("test@mail.com");
            result.Value.Id.Should().Be(_id);
        }
    }
}
