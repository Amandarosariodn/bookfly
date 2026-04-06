using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Application.Usuarios.DataTransfer.Requests;
using bookfly.Application.Usuarios.DataTransfer.Responses;
using bookfly.Application.Usuarios.Services.Interfaces;
using bookfly.Domain.Usuarios.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Usuarios
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController(IUsuariosAppService usuariosAppService) : ControllerBase
    {
        /// <summary>
        // Recuperar todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<UsuarioResponse>>> ListarAsync(
        [FromQuery] ListarUsuarioRequest request,
        CancellationToken cancellationToken)
        {
            var response = await usuariosAppService.ListarAsync(request, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Recuperar um usuário pelo Id
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            UsuarioResponse response = await usuariosAppService.RecuperarAsync(id, cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Editar um usuário pelo Id
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="request">Dados para edição do usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UsuarioResponse>> EditarAsync(int id, [FromBody] EditarUsuarioRequest request, CancellationToken cancellationToken)
        {
            UsuarioResponse response = await usuariosAppService.EditarAsync(id, request, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Mudar situação de um usuário pelo Id
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("/status/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> MudarSituacaoAsync(int id, CancellationToken cancellationToken)
        {
            await usuariosAppService.MudarSituacaoAsync(id, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Inserir uma novo usuário
        /// </summary>
        /// <param name="request">Dados para inserção do usuário</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<UsuarioResponse>> InserirAsync([FromBody] InserirUsuarioRequest request, CancellationToken cancellationToken)
        {
            UsuarioResponse response = await usuariosAppService.InserirAsync(request, cancellationToken);

            return Ok(response);
        }
    }
}