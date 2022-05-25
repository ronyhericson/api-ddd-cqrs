using MediatR;

namespace Stefanini.Application.Features.Commands.Cidade.AddCidadeCommand
{
    public class AddCidadeCommand : IRequest
    {
        public string nome { get; set; }
        public string uf { get; set; }
    }
}
