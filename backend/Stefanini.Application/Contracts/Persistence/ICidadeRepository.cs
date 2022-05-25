using Stefanini.Domain.Entities;

namespace Stefanini.Application.Contracts.Persistence
{
    public interface ICidadeRepository : IAsyncRepository<Cidade>
    {
        Task<IEnumerable<Cidade>> GetCidadeByName(string name);
    }
}
