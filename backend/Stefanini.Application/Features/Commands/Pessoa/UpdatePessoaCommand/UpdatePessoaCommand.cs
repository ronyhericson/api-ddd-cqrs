using MediatR;

namespace Stefanini.Application.Features.Commands.UpdatePessoaCommand
{
    public class UpdatePessoaCommand : IRequest
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public int id_cidade { get; set; }
        public int idade { get; set; }
    }
}
