using System;
using System.Threading.Tasks;
using AutoMapper;
using LapTopShop.Models.DataModels;
using LapTopShop.Models.DTO;
using LapTopShop.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LapTopShop.API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrderController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Action to create an order.
        /// </summary>
        /// <param name="orderDto">Model to create a new order</param>
        /// <returns>Returns the created order</returns>
        /// <response code="200">Returned if the order was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the order couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<GetOrderDto>> Laptop(AddOrderDto orderDto)
        {
            try
            {
                var result = await _mediator.Send(new CreateOrderCommand
                {
                    Order = _mapper.Map<Order>(orderDto)
                });

                return _mapper.Map<GetOrderDto>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
