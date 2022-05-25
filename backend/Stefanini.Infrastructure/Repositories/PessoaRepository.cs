using Microsoft.EntityFrameworkCore;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Domain.Entities;
using Stefanini.Infrastructure.Persistence;

namespace Stefanini.Infrastructure.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Pessoa>> GetPessoaByUserName(string name)
        {
            var pessoaList = await _dbContext.Pessoas
                                .Where(o => o.nome == name)
                                .ToListAsync();
            return pessoaList;
        }
    }
}
