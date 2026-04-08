using bookfly.Application.SeguidorUsuarios.DataTransfer.Responses;
using bookfly.Application.SeguidorUsuarios.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.SeguidorUsuarios
{
    [ApiController]
    [Route("seguidorUsuario/api")]
    public class SeguidorUsuariosController(ISeguidorUsuariosAppService seguidorUsuariosAppService) : ControllerBase
    {

        [HttpGet("seguidores")]
        public async Task<ActionResult<List<SeguidorUsuarioResponse>>> ObterSeguidoresAsync(
        [FromQuery] int usuarioId,
        CancellationToken cancellationToken)
        {
            var response = await seguidorUsuariosAppService.ObterSeguidoresAsync(usuarioId, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpGet("seguindo")]
        public async Task<ActionResult<List<SeguidorUsuarioResponse>>> ObterSeguindoAsync([FromQuery] int usuarioId, CancellationToken cancellationToken)
        {
            var response = await seguidorUsuariosAppService.ObterSeguindoAsync(usuarioId, cancellationToken);

            if (response == null || !response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpDelete("unfollow")]
        public async Task<IActionResult> DeixarDeSeguir(
        [FromQuery] int seguidorId,
        [FromQuery] int seguidoId,
        CancellationToken cancellationToken)
        {
            await seguidorUsuariosAppService
                .DeixarDeSeguirAsync(seguidorId, seguidoId, cancellationToken);

            return NoContent();
        }

        [HttpGet("is-following")]
        public async Task<ActionResult<bool>> JaSeguindo(
                [FromQuery] int seguidorId,
                [FromQuery] int seguidoId,
                CancellationToken cancellationToken)
        {
            var response = await seguidorUsuariosAppService.JaSeguindoAsync(
                seguidorId,
                seguidoId,
                cancellationToken);

            return Ok(response);
        }

        [HttpPost("follow")]
        public async Task<IActionResult> Seguir(
        [FromQuery] int seguidorId,
        [FromQuery] int seguidoId,
        CancellationToken cancellationToken)
        {
            await seguidorUsuariosAppService.SeguirAsync(
                seguidorId,
                seguidoId,
                cancellationToken);

            return NoContent();
        }


    }
}