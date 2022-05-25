using MediatR;

namespace Stefanini.Application.Features.Commands.DeletePessoaCommand
{
    public class DeletePessoaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
