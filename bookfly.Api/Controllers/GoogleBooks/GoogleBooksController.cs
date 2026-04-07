using bookfly.Domain.GoogleBooks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers
{
    [ApiController]
    [Route("api/google-books")]
    public class GoogleBooksController : ControllerBase
    {
        private readonly IGoogleBooksService _service;

        public GoogleBooksController(
            IGoogleBooksService service)
        {
            _service = service;
        }

        // Buscar por título
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorTitulo(
            [FromQuery] string titulo,
            CancellationToken cancellationToken)
        {
            var resultado =
                await _service.BuscarPorTituloAsync(
                    titulo,
                    cancellationToken);

            return Ok(resultado);
        }

        // Buscar por ID
        [HttpGet("{googleBooksId}")]
        public async Task<IActionResult> BuscarPorId(
            string googleBooksId,
            CancellationToken cancellationToken)
        {
            var resultado =
                await _service.BuscarPorIdAsync(
                    googleBooksId,
                    cancellationToken);

            if (resultado == null)
                return NotFound("Livro não encontrado");

            return Ok(resultado);
        }
    }
}