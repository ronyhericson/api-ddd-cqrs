using MediatR;
using Stefanini.Application.Features.Queries.GetPessoasList;

namespace Stefanini.Application.Features.Queries.GetAllPessoas
{
    public class GetAllPessoasQuery : IRequest<List<PessoasViewModel>>
    {
    }
}
