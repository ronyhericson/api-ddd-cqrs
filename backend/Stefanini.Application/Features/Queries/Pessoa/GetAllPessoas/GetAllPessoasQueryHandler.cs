using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Application.Features.Queries.GetPessoasList;

namespace Stefanini.Application.Features.Queries.GetAllPessoas
{
    public class GetAllPessoasQueryHandler : IRequestHandler<GetAllPessoasQuery, List<PessoasViewModel>>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public GetAllPessoasQueryHandler(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PessoasViewModel>> Handle(GetAllPessoasQuery request, CancellationToken cancellationToken)
        {
            var pessoaList = await _pessoaRepository.GetAllAsync();
            return _mapper.Map<List<PessoasViewModel>>(pessoaList);
        }
    }
}
