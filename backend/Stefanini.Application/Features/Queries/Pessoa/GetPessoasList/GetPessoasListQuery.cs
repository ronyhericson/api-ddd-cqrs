using MediatR;

namespace Stefanini.Application.Features.Queries.GetPessoasList
{
    public class GetPessoasListQuery : IRequest<List<PessoasViewModel>>
    {
        public string nome { get; set; }

        public GetPessoasListQuery(string nome)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }
    }
}
