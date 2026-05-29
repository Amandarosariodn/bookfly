using bookfly.Application.Estantes.DataTransfer.Requests;
using bookfly.Application.Estantes.DataTransfer.Responses;
using bookfly.Application.Estantes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Estantes
{
    [ApiController]
    [Route("estantes")]
    public class EstantesController(IEstantesAppService estantesAppService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<EstanteResponse>>> ListarAsync(
            [FromQuery] ListarEstanteRequest request,
            CancellationToken cancellationToken)
        {
            var response = await estantesAppService.ListarAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<EstanteResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstanteResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            EstanteResponse response = await estantesAppService.RecuperarAsync(id, cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<EstanteResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<EstanteResponse>> InserirAsync([FromBody] InserirEstanteRequest request, CancellationToken cancellationToken)
        {
            EstanteResponse response = await estantesAppService.InserirAsync(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType<EstanteResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<EstanteResponse>> EditarAsync(int id, [FromBody] EditarEstanteRequest request, CancellationToken cancellationToken)
        {
            EstanteResponse response = await estantesAppService.EditarAsync(id, request, cancellationToken);

            return Ok(response);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            await estantesAppService.MudarSituacaoAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
