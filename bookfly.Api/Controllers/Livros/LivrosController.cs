
using bookfly.Application.Livros.DataTransfer.Requests;
using bookfly.Application.Livros.DataTransfer.Responses;
using bookfly.Application.Livros.Services.Interfaces;
using bookfly.Domain.Livros.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Livros
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController(ILivrosAppServices livrosAppServices) : ControllerBase
    {

        /// <summary>
        // Recuperar todos os livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<LivroResponse>>> ListarAsync(
        [FromQuery] ListarLivroRequest request,
        CancellationToken cancellationToken)
        {
            var response = await livrosAppServices.ListarAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Recuperar um livro pelo Id
        /// </summary>
        /// <param name="id">Id do livro</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType<LivroResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LivroResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            LivroResponse response = await livrosAppServices.RecuperarAsync(id, cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Editar um livro pelo Id
        /// </summary>
        /// <param name="id">Id do livro</param>
        /// <param name="request">Dados para edição do livro</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<LivroResponse>> EditarAsync(int id, [FromBody] EditarLivroRequest request, CancellationToken cancellationToken)
        {
            LivroResponse response = await livrosAppServices.EditarAsync(id, request, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Mudar situação de um livro pelo Id
        /// </summary>
        /// <param name="id">Id do livro</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("/status/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            await livrosAppServices.MudarSituacaoAsync(id, cancellationToken);

            return NoContent();
        }
        
        /// <summary>
        /// Inserir uma novo livro
        /// </summary>
        /// <param name="request">Dados para inserção do livro</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<LivroResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<LivroResponse>> InserirAsync([FromBody] InserirLivroRequest request, CancellationToken cancellationToken)
        {
            LivroResponse response = await livrosAppServices.InserirAsync(request, cancellationToken);

            return Ok(response);
        }
    }
}