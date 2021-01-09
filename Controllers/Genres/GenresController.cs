using System;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Genres.Commands;
using LocadoraAspNet.Controllers.Genres.ViewModels;
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
                return BadRequest(exception);
            return Ok(_mapper.Map<Genre, GenreViewModel>(result));
        }
    }
}