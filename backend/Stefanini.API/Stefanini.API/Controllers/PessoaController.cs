
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Application.Features.Commands.AddPessoaCommand;
using Stefanini.Application.Features.Commands.DeletePessoaCommand;
using Stefanini.Application.Features.Commands.UpdatePessoaCommand;
using Stefanini.Application.Features.Queries.GetAllPessoas;
using Stefanini.Application.Features.Queries.GetPessoasList;
using System.Net;

namespace Stefanini.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PessoaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(Name = "CreatePessoa")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreatePessoa([FromBody] AddPessoaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut(Name = "UpdatePessoa")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePessoa([FromBody] UpdatePessoaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePessoa")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePessoa(int id)
        {
            var command = new DeletePessoaCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{nome}", Name = "GetPessoas")]
        [ProducesResponseType(typeof(IEnumerable<PessoasViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PessoasViewModel>>> GetPessoasByName(string nome)
        {
            var query = new GetPessoasListQuery(nome);
            var pessoas = await _mediator.Send(query);
            return Ok(pessoas);
        }

        [HttpGet(Name = "GetAllPessoas")]
        [ProducesResponseType(typeof(IEnumerable<PessoasViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PessoasViewModel>>> GetAllPessoas()
        {
            var query = new GetAllPessoasQuery();
            var pessoas = await _mediator.Send(query);
            return Ok(pessoas);
        }
    }
}
