using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Infrastructure.Persistence;
using Stefanini.Infrastructure.Repositories;

namespace Stefanini.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();

            return services;
        }
    }
}
