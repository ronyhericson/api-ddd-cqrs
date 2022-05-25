using MediatR;

namespace Stefanini.Application.Features.Commands.Cidade.UpdateCidadeCommand
{
    public class UpdateCidadeCommand : IRequest
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        
    }
}
