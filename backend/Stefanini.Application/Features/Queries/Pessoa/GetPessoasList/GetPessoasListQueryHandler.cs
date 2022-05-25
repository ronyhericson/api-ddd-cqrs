using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;

namespace Stefanini.Application.Features.Queries.GetPessoasList
{
    public class GetPessoasListQueryHandler : IRequestHandler<GetPessoasListQuery, List<PessoasViewModel>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public GetPessoasListQueryHandler(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PessoasViewModel>> Handle(GetPessoasListQuery request, CancellationToken cancellationToken)
        {
            var pessoaList = await _pessoaRepository.GetPessoaByUserName(request.nome);
            return _mapper.Map<List<PessoasViewModel>>(pessoaList);
        }
    }
}
