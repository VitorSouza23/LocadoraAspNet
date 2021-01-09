using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Locations.Commands;
using LocadoraAspNet.Application.Features.Locations.Queries;
using LocadoraAspNet.Controllers.Locations.ViewModels;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAspNet.Controllers.Locations
{
    /// <summary>
    /// Endpoint de locações
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LocationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona uma nova locação
        /// </summary>
        /// <param name="addLocationCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LocationViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Add([FromBody] AddLocationCommand addLocationCommand)
        {
            (Exception exception, Location result) = await _mediator.Send(addLocationCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Location, LocationViewModel>(result));
        }

        /// <summary>
        /// Encontra todos as locações cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LocationViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetAll()
        {
            (Exception exception, IEnumerable<Location> locations) = await _mediator.Send(new GetAllLocationsQuery());
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(locations));
        }

        /// <summary>
        /// Encontra uma locação através de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(LocationViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetById(int id)
        {
            (Exception exception, Location reuslt) = await _mediator.Send(new GetLocationByIdQuery() { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Location, LocationViewModel>(reuslt));
        }

        /// <summary>
        /// Atualiza os dados de uma locação
        /// </summary>
        /// <param name="putLocationCommand"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(LocationViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Put([FromBody] PutLocationCommand putLocationCommand)
        {
            (Exception exception, Location result) = await _mediator.Send(putLocationCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Location, LocationViewModel>(result));
        }

        /// <summary>
        /// Remove uma locação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(LocationViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Delete(int id)
        {
            (Exception exception, Location result) = await _mediator.Send(new DeleteLocationCommand { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Location, LocationViewModel>(result));
        }
    }
}