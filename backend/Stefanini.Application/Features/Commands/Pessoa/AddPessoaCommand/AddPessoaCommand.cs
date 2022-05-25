using MediatR;

namespace Stefanini.Application.Features.Commands.AddPessoaCommand
{
    public class AddPessoaCommand : IRequest
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public int id_cidade { get; set; }
        public int idade { get; set; }
    }
}
