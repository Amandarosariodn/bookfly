using bookfly.Application.EstanteLivros.DataTransfer.Requests;
using bookfly.Application.EstanteLivros.DataTransfer.Responses;
using bookfly.Application.EstanteLivros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.EstanteLivros
{
    [ApiController]
    [Route("estante-livros")]
    public class EstanteLivrosController(IEstanteLivrosAppServices estanteLivrosAppServices) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<EstanteLivroResponse>>> ListarAsync(
            [FromQuery] ListarEstanteLivroRequest request,
            CancellationToken cancellationToken)
        {
            var response = await estanteLivrosAppServices.ListarAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<EstanteLivroResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstanteLivroResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            EstanteLivroResponse response = await estanteLivrosAppServices.RecuperarAsync(id, cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<EstanteLivroResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<EstanteLivroResponse>> InserirAsync([FromBody] InserirEstanteLivroRequest request, CancellationToken cancellationToken)
        {
            EstanteLivroResponse response = await estanteLivrosAppServices.InserirEstanteLivroAsync(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType<EstanteLivroResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<EstanteLivroResponse>> EditarAsync(int id, [FromBody] EditarEstanteLivroRequest request, CancellationToken cancellationToken)
        {
            EstanteLivroResponse response = await estanteLivrosAppServices.EditarEstanteLivroAsync(request, id, cancellationToken);

            return Ok(response);
        }
    }
}
