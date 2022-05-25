using Stefanini.Domain.Entities;

namespace Stefanini.Application.Contracts.Persistence
{
    public interface IPessoaRepository : IAsyncRepository<Pessoa>
    {
        Task<IEnumerable<Pessoa>> GetPessoaByUserName(string name);
    }
}
