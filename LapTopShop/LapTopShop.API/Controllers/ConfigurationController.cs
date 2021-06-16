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
    public class ConfigurationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ConfigurationController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Action to see all existing configurations.
        /// </summary>
        /// <returns>Returns a list of all configurations</returns>
        /// <response code="200">Returned if the configurations were loaded.</response>
        /// <response code="400">Returned if the configurations couldn't be loaded./response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<GetConfigurationDto>>> Configurations()
        {
            try
            {
                var configurationList = await _mediator.Send(new GetConfigurationsQuery());
                return _mapper.Map<List<Configuration>, List<GetConfigurationDto>>(configurationList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action to create a new customer in the database.
        /// </summary>
        /// <param name="AddLaptopDto">Model to create a new configuration</param>
        /// <returns>Returns the created customer</returns>
        /// <response code="200">Returned if the configuration was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the configuration couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<GetConfigurationDto>> Configuration(AddConfigurationDto configurationModelDto)
        {
            try
            {
                var result = await _mediator.Send(new CreateConfigurationCommand
                {
                    Configuration = _mapper.Map<Configuration>(configurationModelDto),
                });

                return _mapper.Map<GetConfigurationDto>(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
