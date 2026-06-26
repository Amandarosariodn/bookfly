using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Application.Metas.DataTransfer.Requests;
using bookfly.Application.Metas.DataTransfer.Responses;
using bookfly.Application.Metas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bookfly.Api.Controllers.Metas
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetasController : ControllerBase
    {
        private readonly IMetasAppService metasAppService;

        /// <summary>
        /// Recuperar uma meta pelo Id
        /// </summary>
        /// <param name="id">Id da meta</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "Recuperar-meta")]
        [ProducesResponseType<MetaResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MetaResponse>> RecuperarAsync(int id, CancellationToken cancellationToken)
        {
            MetaResponse response = await metasAppService.RecuperarAsync(id, cancellationToken);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Editar uma meta pelo Id
        /// </summary>
        /// <param name="id">Id da meta</param>
        /// <param name="request">Dados para edição da meta</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<MetaResponse>> EditarAsync(int id, [FromBody] EditarMetaRequest request, CancellationToken cancellationToken)
        {
            MetaResponse response = await metasAppService.EditarAsync(id, request, cancellationToken);

            return Ok(response);
        }

        
        [HttpPost]
        public async Task<ActionResult<MetaResponse>> InserirAsync(
            [FromBody] InserirMetaRequest request,
            CancellationToken cancellationToken)
        {
            string? authorization = Request.Headers.Authorization;

            if (string.IsNullOrWhiteSpace(authorization))
                return Unauthorized();

            string token = authorization.Replace("Bearer ", "");

            MetaResponse response = await metasAppService.InserirAsync(request, token, cancellationToken);

            return Created("", response);
        }
    }
}