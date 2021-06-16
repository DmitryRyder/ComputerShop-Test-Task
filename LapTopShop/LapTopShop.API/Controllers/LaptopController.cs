using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LapTopShop.Models.DataModels;
using LapTopShop.Models.DTO;
using LapTopShop.Service.Commands;
using LapTopShop.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LapTopShop.API.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public LaptopController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Action to see all existing laptops.
        /// </summary>
        /// <returns>Returns a list of all laptops</returns>
        /// <response code="200">Returned if the laptops were loaded</response>
        /// <response code="400">Returned if the laptops couldn't be loaded</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<GetLaptopDto>>> Laptops()
        {
            try
            {
                var laptops = await _mediator.Send(new GetLaptopsQuery());
                return _mapper.Map<List<Laptop>, List<GetLaptopDto>>(laptops);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action to create a new customer in the database.
        /// </summary>
        /// <param name="AddLaptopDto">Model to create a new laptop</param>
        /// <returns>Returns the created customer</returns>
        /// <response code="200">Returned if the laptop was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the laptop couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<GetLaptopDto>> Laptop(AddLaptopDto laptopDto)
        {
            try
            {
                var result = await _mediator.Send(new CreateLaptopCommand
                {
                    Laptop = _mapper.Map<Laptop>(laptopDto)
                });

                return _mapper.Map<GetLaptopDto>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
