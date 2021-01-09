using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Genres.Commands;
using LocadoraAspNet.Application.Features.Genres.Queries;
using LocadoraAspNet.Controllers.Genres.ViewModels;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAspNet.Controllers.Genres
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GenresController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        public async Task<IActionResult> Add([FromBody] AddGenreCommand addGenreCommand)
        {
            (Exception exception, Genre result) = await _mediator.Send(addGenreCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(result));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GenreViewModel>))]
        public async Task<IActionResult> GetAll()
        {
            (Exception exception, IEnumerable<Genre> genres) = await _mediator.Send(new GetAllGenresQuery());
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        public async Task<IActionResult> GetById(int id)
        {
            (Exception exception, Genre genres) = await _mediator.Send(new GetGenreByIdQuery() { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(genres));
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        public async Task<IActionResult> Put([FromBody] PutGenreCommand putGenreCommand)
        {
            (Exception exception, Genre result) = await _mediator.Send(putGenreCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(result));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        public async Task<IActionResult> Delete(int id)
        {
            (Exception exception, Genre result) = await _mediator.Send(new DeleteGenreComand { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(result));
        }
    }
}