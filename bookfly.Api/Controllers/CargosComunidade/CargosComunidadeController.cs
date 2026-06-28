using bookfly.Application.CargosComunidade.DataTransfer.Requests;
using bookfly.Application.CargosComunidade.DataTransfer.Responses;
using bookfly.Application.CargosComunidade.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.CargosComunidade
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargosComunidadeController : ControllerBase
    {
        private readonly ICargoComunidadeAppService cargoComunidadeAppService;

        public CargosComunidadeController(ICargoComunidadeAppService cargoComunidadeAppService)
        {
            this.cargoComunidadeAppService = cargoComunidadeAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<CargoComunidadeResponse>>> ListarAsync(
            [FromQuery] ListarCargoComunidadeRequest request,
            CancellationToken cancellationToken)
        {
            var response = await cargoComunidadeAppService.ListarAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<CargoComunidadeResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CargoComunidadeResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            CargoComunidadeResponse response = await cargoComunidadeAppService.RecuperarAsync(id, cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<CargoComunidadeResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<CargoComunidadeResponse>> InserirAsync([FromBody] InserirCargoComunidadeRequest request, CancellationToken cancellationToken)
        {
            CargoComunidadeResponse response = await cargoComunidadeAppService.InserirAsync(request, cancellationToken);
            return CreatedAtAction(nameof(RecuperarAsync), new { id = response.Id }, response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType<CargoComunidadeResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<CargoComunidadeResponse>> EditarAsync(int id, [FromBody] EditarCargoComunidadeRequest request, CancellationToken cancellationToken)
        {
            CargoComunidadeResponse response = await cargoComunidadeAppService.EditarAsync(id, request, cancellationToken);
            return Ok(response);
        }
    }
}
