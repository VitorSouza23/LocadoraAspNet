using System;
using System.Threading.Tasks;
using LocadoraAspNet.Application.Features.Genres.Commands;
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

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGenreCommand addGenreCommand)
        {
            (Exception exception, Genre result) = await _mediator.Send(addGenreCommand);
            if (exception != null)
                return BadRequest(exception);
            return Ok(result);
        }
    }
}