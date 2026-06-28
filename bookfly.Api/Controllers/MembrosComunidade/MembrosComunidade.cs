
using bookfly.Application.MembrosComunidade.DataTransfer.Requests;
using bookfly.Application.MembrosComunidade.DataTransfer.Responses;
using bookfly.Application.MembrosComunidade.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.MembrosComunidade
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembrosComunidade(IMembroComunidadeAppService membroComunidadeAppService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<MembroComunidadeResponse>>> ListarAsync(
            [FromQuery] ListarMembroComunidadeRequest request,
            CancellationToken cancellationToken)
        {
            var response = await membroComunidadeAppService.ListarAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<MembroComunidadeResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MembroComunidadeResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            MembroComunidadeResponse response = await membroComunidadeAppService.RecuperarAsync(id, cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<MembroComunidadeResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<MembroComunidadeResponse>> InserirAsync([FromBody] InserirMembroComunidadeRequest request, CancellationToken cancellationToken)
        {
            MembroComunidadeResponse response = await membroComunidadeAppService.InserirAsync(request, cancellationToken);
            return CreatedAtAction(nameof(RecuperarAsync), new { id = response.Id }, response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType<MembroComunidadeResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<MembroComunidadeResponse>> EditarAsync(int id, [FromBody] EditarMembroComunidadeRequest request, CancellationToken cancellationToken)
        {
            MembroComunidadeResponse response = await membroComunidadeAppService.EditarAsync(id, request, cancellationToken);
            return Ok(response);
        }
    }
}