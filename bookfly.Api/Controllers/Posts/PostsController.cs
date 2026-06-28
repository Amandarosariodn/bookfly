using bookfly.Application.Posts.DataTransfer.Requests;
using bookfly.Application.Posts.DataTransfer.Responses;
using bookfly.Application.Posts.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Posts
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostAppService postAppService;

        public PostsController(IPostAppService postAppService)
        {
            this.postAppService = postAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<PostResponse>>> ListarAsync([FromQuery] ListarPostRequest request, CancellationToken cancellationToken)
        {
            var response = await postAppService.ListarAsync(request, cancellationToken);
            if (response == null || !response.Any())
                return NoContent();
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType<PostResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostResponse>> RecuperarAsync(long id, CancellationToken cancellationToken)
        {
            PostResponse response = await postAppService.RecuperarAsync(id, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<PostResponse>(StatusCodes.Status201Created)]
        public async Task<ActionResult<PostResponse>> InserirAsync([FromBody] InserirPostRequest request, CancellationToken cancellationToken)
        {
            PostResponse response = await postAppService.InserirAsync(request, cancellationToken);
            return CreatedAtAction(nameof(RecuperarAsync), new { id = response.Id }, response);
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType<PostResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<PostResponse>> EditarAsync(long id, [FromBody] EditarPostRequest request, CancellationToken cancellationToken)
        {
            PostResponse response = await postAppService.EditarAsync(id, request, cancellationToken);
            return Ok(response);
        }
    }
}