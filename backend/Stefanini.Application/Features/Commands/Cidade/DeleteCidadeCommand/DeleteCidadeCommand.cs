using MediatR;

namespace Stefanini.Application.Features.Commands.Cidade.DeleteCidadeCommand
{
    public class DeleteCidadeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
