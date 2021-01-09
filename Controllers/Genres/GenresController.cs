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
    /// <summary>
    /// Endpoint de gêneros de filmes
    /// </summary>
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

        /// <summary>
        /// Adiciona um novo gênero de filmes
        /// </summary>
        /// <param name="addGenreCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Add([FromBody] AddGenreCommand addGenreCommand)
        {
            (Exception exception, Genre result) = await _mediator.Send(addGenreCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(result));
        }

        /// <summary>
        /// Encontra todos os gêneros de filmes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GenreViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetAll()
        {
            (Exception exception, IEnumerable<Genre> genres) = await _mediator.Send(new GetAllGenresQuery());
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres));
        }

        /// <summary>
        /// Encontra um gênero de filme através de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetById(int id)
        {
            (Exception exception, Genre genre) = await _mediator.Send(new GetGenreByIdQuery() { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(genre));
        }

        /// <summary>
        /// Atualiza os dados de um gênero de filme
        /// </summary>
        /// <param name="putGenreCommand"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Put([FromBody] PutGenreCommand putGenreCommand)
        {
            (Exception exception, Genre result) = await _mediator.Send(putGenreCommand);
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(result));
        }

        /// <summary>
        /// Remove um gênero de filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200, Type = typeof(GenreViewModel))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> Delete(int id)
        {
            (Exception exception, Genre result) = await _mediator.Send(new DeleteGenreCommand { Id = id });
            if (exception != null)
                return BadRequest(new ExceptionPayload(exception.Message));
            return Ok(_mapper.Map<Genre, GenreViewModel>(result));
        }
    }
}