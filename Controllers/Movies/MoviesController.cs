using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Moveis.Commands;
using AutoMapper;
using LocadoraAspNet.Application.Features.Moveis.Commands;
using LocadoraAspNet.Application.Features.Movies.Commands;
using LocadoraAspNet.Application.Features.Movies.Queries;
using LocadoraAspNet.Controllers.Movies.ViewModels;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraAspNet.Controllers.Movies
{
    /// <summary>
    /// Endpoint de filmes
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MoviesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um novo filme
        /// </summary>
        /// <param name="addMovieCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(MovieViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Add([FromBody] AddMovieCommand addMovieCommand)
        {
            (Exception exception, Movie result) = await _mediator.Send(addMovieCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Movie, MovieViewModel>(result));
        }

        /// <summary>
        /// Encontra um filme de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(MovieViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetById(int id)
        {
            (Exception exception, Movie movie) = await _mediator.Send(new GetMovieByIdQuery { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Movie, MovieViewModel>(movie));
        }

        /// <summary>
        /// Encontra todos os filmes
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MovieViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetAll()
        {
            (Exception exception, IEnumerable<Movie> movies) = await _mediator.Send(new GetAllMoviesQuery());
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies));
        }

        /// <summary>
        /// Atualiza os dados de um filme
        /// </summary>
        /// <param name="putMovieCommand"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(MovieViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Put([FromBody] PutMovieCommand putMovieCommand)
        {
            (Exception exception, Movie result) = await _mediator.Send(putMovieCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Movie, MovieViewModel>(result));
        }

        /// <summary>
        /// Remove um filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(MovieViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Delete(int id)
        {
            (Exception exception, Movie result) = await _mediator.Send(new DeleteMovieCommand { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Movie, MovieViewModel>(result));
        }

        /// <summary>
        /// Remove vários filmes
        /// </summary>
        /// <param name="deleteManyMoviesCommand"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MovieViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> DeleteMany([FromBody] DeleteManyMoviesCommand deleteManyMoviesCommand)
        {
            (Exception exception, IEnumerable<Movie> result) = await _mediator.Send(deleteManyMoviesCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(result));
        }
    }
}