using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Application.Features.Commands.Cidade.AddCidadeCommand;
using Stefanini.Application.Features.Commands.Cidade.DeleteCidadeCommand;
using Stefanini.Application.Features.Commands.Cidade.UpdateCidadeCommand;
using Stefanini.Application.Features.Queries.Cidade.GetAllCidades;
using System.Net;

namespace Stefanini.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CidadeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(Name = "CreateCidade")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateCidade([FromBody] AddCidadeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut(Name = "UpdateCidade")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCidade([FromBody] UpdateCidadeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCidade")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCidade(int id)
        {
            var command = new DeleteCidadeCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet(Name = "GetAllCidades")]
        [ProducesResponseType(typeof(IEnumerable<CidadeViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CidadeViewModel>>> GetAllCidades()
        {
            var query = new GetAllCidadesQuery();
            var cidades = await _mediator.Send(query);
            return Ok(cidades);
        }
    }
}
