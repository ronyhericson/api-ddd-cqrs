using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stefanini.Application.Features.Commands.AddPessoaCommand;
using Stefanini.Application.Features.Commands.Cidade.AddCidadeCommand;
using Stefanini.Application.Features.Commands.Cidade.DeleteCidadeCommand;
using Stefanini.Application.Features.Commands.Cidade.UpdateCidadeCommand;
using Stefanini.Application.Features.Commands.DeletePessoaCommand;
using Stefanini.Application.Features.Commands.UpdatePessoaCommand;
using Stefanini.Application.Features.Queries.GetAllPessoas;
using Stefanini.Application.Features.Queries.GetPessoasList;
using System.Reflection;

namespace Stefanini.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());     
            
            //Add Scoped Commands Injection
            services.AddMediatR(typeof(AddPessoaCommand));
            services.AddMediatR(typeof(UpdatePessoaCommand));
            services.AddMediatR(typeof(DeletePessoaCommand));

            services.AddMediatR(typeof(AddCidadeCommand));
            services.AddMediatR(typeof(UpdateCidadeCommand));
            services.AddMediatR(typeof(DeleteCidadeCommand));

            //Add Scoped Queries Injection 
            services.AddMediatR(typeof(GetPessoasListQuery));
            services.AddMediatR(typeof(GetAllPessoasQuery));

            return services;
        }
    }
}
