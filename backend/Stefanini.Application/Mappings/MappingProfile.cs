using AutoMapper;
using Stefanini.Application.Features.Commands.AddPessoaCommand;
using Stefanini.Application.Features.Commands.Cidade.AddCidadeCommand;
using Stefanini.Application.Features.Commands.Cidade.UpdateCidadeCommand;
using Stefanini.Application.Features.Commands.UpdatePessoaCommand;
using Stefanini.Application.Features.Queries.Cidade.GetAllCidades;
using Stefanini.Application.Features.Queries.GetPessoasList;
using Stefanini.Domain.Entities;

namespace Stefanini.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, AddPessoaCommand>().ReverseMap();
            CreateMap<Pessoa, UpdatePessoaCommand>().ReverseMap();
            CreateMap<Pessoa, PessoasViewModel>().ReverseMap();

            CreateMap<Cidade, AddCidadeCommand>().ReverseMap();
            CreateMap<Cidade, UpdateCidadeCommand>().ReverseMap();
            CreateMap<Cidade, CidadeViewModel>().ReverseMap();
        }
    }
}
