using Microsoft.EntityFrameworkCore;
using Stefanini.Domain.Entities;

namespace Stefanini.Infrastructure.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {   
            return base.SaveChangesAsync(cancellationToken);
        }        
    }
}
