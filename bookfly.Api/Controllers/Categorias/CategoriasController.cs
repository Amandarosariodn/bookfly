using bookfly.Application.Categorias.DataTransfer.Requests;
using bookfly.Application.Categorias.DataTransfer.Responses;
using bookfly.Application.Categorias.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autoglass.AutoPlay.API.Controllers.Categorias
{

    /// <summary>
    /// Controller responsável por listar informações das categorias
    /// </summary>
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAppService _categoriasAppService;
        public CategoriasController(ICategoriasAppService categoriasAppService)
        {
            _categoriasAppService = categoriasAppService;
        }

        /// <summary>
        /// Recuperar todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<CategoriaResponse>>> ListarAsync(
        [FromQuery] ListarCategoriaRequest request,
        CancellationToken cancellationToken)
        {
            var response = await _categoriasAppService.ListarAsync(request, cancellationToken);

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
        [ProducesResponseType<CategoriaResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            CategoriaResponse response = await _categoriasAppService.RecuperarAsync(id, cancellationToken);

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
        public async Task<ActionResult<CategoriaResponse>> EditarAsync(int id, [FromBody] EditarCategoriaRequest request, CancellationToken cancellationToken)
        {
            CategoriaResponse response = await _categoriasAppService.EditarAsync(id, request, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Mudar situação de uma categoria pelo Id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            await _categoriasAppService.MudarSituacaoAsync(id, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Inserir uma nova categoria
        /// </summary>
        /// <param name="request">Dados para inserção da categoria</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<CategoriaResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<CategoriaResponse>> InserirAsync([FromBody] InserirCategoriaRequest request, CancellationToken cancellationToken)
        {
            CategoriaResponse response = await _categoriasAppService.InserirAsync(request, cancellationToken);

            return Ok(response);
        }
    }
}