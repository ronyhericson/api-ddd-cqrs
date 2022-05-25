using MediatR;

namespace Stefanini.Application.Features.Queries.Cidade.GetAllCidades
{
    public class GetAllCidadesQuery : IRequest<List<CidadeViewModel>>
    {
    }
}
