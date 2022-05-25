using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;

namespace Stefanini.Application.Features.Queries.Cidade.GetAllCidades
{
    public class GetAllCidadesQueryHandler : IRequestHandler<GetAllCidadesQuery, List<CidadeViewModel>>
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public GetAllCidadesQueryHandler(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository ?? throw new ArgumentNullException(nameof(cidadeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CidadeViewModel>> Handle(GetAllCidadesQuery request, CancellationToken cancellationToken)
        {
            var cidadeList = await _cidadeRepository.GetAllAsync();
            return _mapper.Map<List<CidadeViewModel>>(cidadeList);
        }
    }
}
