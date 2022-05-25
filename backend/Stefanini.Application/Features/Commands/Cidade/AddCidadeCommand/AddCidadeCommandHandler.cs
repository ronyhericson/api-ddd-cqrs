using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;

namespace Stefanini.Application.Features.Commands.Cidade.AddCidadeCommand
{
    public class AddCidadeCommandHandler : IRequestHandler<AddCidadeCommand>
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public AddCidadeCommandHandler(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository ?? throw new ArgumentNullException(nameof(cidadeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(AddCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidadeToAdd = new Stefanini.Domain.Entities.Cidade();
            _mapper.Map(request, cidadeToAdd, typeof(AddCidadeCommand), typeof(Stefanini.Domain.Entities.Cidade));

            await _cidadeRepository.AddAsync(cidadeToAdd);

            return Unit.Value;
        }
    }
}
