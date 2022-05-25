using Microsoft.EntityFrameworkCore;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Domain.Entities;
using Stefanini.Infrastructure.Persistence;

namespace Stefanini.Infrastructure.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        public CidadeRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Cidade>> GetCidadeByName(string name)
        {
            var cidadeList = await _dbContext.Cidades
                                .Where(o => o.nome == name)
                                .ToListAsync();
            return cidadeList;
        }
    }
}
