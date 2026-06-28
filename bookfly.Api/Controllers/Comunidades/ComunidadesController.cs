
using bookfly.Application.Comunidades.DataTransfer.Requests;
using bookfly.Application.Comunidades.DataTransfer.Responses;
using bookfly.Application.Comunidades.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Comunidades
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunidadesController(IComunidadeAppService comunidadeAppService): ControllerBase
    {
         [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<ComunidadeResponse>>> ListarAsync(
            [FromQuery] ComunidadeListarRequest request,
            CancellationToken cancellationToken)
        {
            var response = await comunidadeAppService.ListarAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<ComunidadeResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ComunidadeResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            ComunidadeResponse response = await comunidadeAppService.RecuperarAsync(id, cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<ComunidadeResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<ComunidadeResponse>> InserirAsync([FromBody] ComunidadeInserirRequest request, CancellationToken cancellationToken)
        {
            ComunidadeResponse response = await comunidadeAppService.InserirAsync(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType<ComunidadeResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<ComunidadeResponse>> EditarAsync(int id, [FromBody] ComunidadeEditarRequest request, CancellationToken cancellationToken)
        {
            ComunidadeResponse response = await comunidadeAppService.EditarAsync(id, request, cancellationToken);

            return Ok(response);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            await comunidadeAppService.MudarSituacaoAsync(id, cancellationToken);

            return NoContent();
        }
    }
}