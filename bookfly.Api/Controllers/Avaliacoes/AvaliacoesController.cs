
using bookfly.Application.Avaliacoes.DataTransfer.Requests;
using bookfly.Application.Avaliacoes.DataTransfer.Responses;
using bookfly.Application.Avaliacoes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Avaliacoes
{
    [ApiController]
    [Route("avaliacoes-livros")]
    public class AvaliacoesController(IAvaliacaoAppService avaliacaoAppService) : ControllerBase
    {
         /// <summary>
        /// Recuperar todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<AvaliacaoResponse>>> ListarAsync(
        [FromQuery] ListarAvaliacaoRequest request,
        CancellationToken cancellationToken)
        {
            var response = await avaliacaoAppService.ListarAvaliacoesAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Recuperar uma categoria pelo Id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "Recuperar")]
        [ProducesResponseType<AvaliacaoResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AvaliacaoResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            AvaliacaoResponse response = await avaliacaoAppService.ObterPorIdAsync(id, cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Editar uma categoria pelo Id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="request">Dados para edição da categoria</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<AvaliacaoResponse>> EditarAsync(int id, [FromBody] EditarAvaliacaoRequest request, CancellationToken cancellationToken)
        {
            AvaliacaoResponse response = await avaliacaoAppService.EditarAsync(request, id, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Excluir uma categoria pelo Id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync(int id, CancellationToken cancellationToken)
        {
            await avaliacaoAppService.ExcluirAsync(id, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Inserir uma nova categoria
        /// </summary>
        /// <param name="request">Dados para inserção da categoria</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<AvaliacaoResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<AvaliacaoResponse>> InserirAsync([FromBody] InserirAvaliacaoRequest request, CancellationToken cancellationToken)
        {
            AvaliacaoResponse response = await avaliacaoAppService.InserirAsync(request, cancellationToken);

            return Ok(response);
        }
    }
}