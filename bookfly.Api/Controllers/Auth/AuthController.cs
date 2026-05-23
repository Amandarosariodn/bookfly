using bookfly.Application.Usuarios.DataTransfer.Requests;
using bookfly.Application.Usuarios.DataTransfer.Responses;
using bookfly.Application.Usuarios.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Auth
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IUsuariosAppService usuariosAppService) : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponse>> LoginAsync(
            [FromBody] LoginRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                LoginResponse response = await usuariosAppService.LoginAsync(request, cancellationToken);

                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
