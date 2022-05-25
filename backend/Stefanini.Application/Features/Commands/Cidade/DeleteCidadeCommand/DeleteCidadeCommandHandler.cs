using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Application.Exceptions;

namespace Stefanini.Application.Features.Commands.Cidade.DeleteCidadeCommand
{
    public class DeleteCidadeCommandHandler : IRequestHandler<DeleteCidadeCommand>
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public DeleteCidadeCommandHandler(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository ?? throw new ArgumentNullException(nameof(cidadeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(DeleteCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidadeToDelete = await _cidadeRepository.GetByIdAsync(request.Id);
            if (cidadeToDelete == null)
            {
                throw new NotFoundException(nameof(Stefanini.Domain.Entities.Cidade), request.Id);
            }

            await _cidadeRepository.DeleteAsync(cidadeToDelete);

            return Unit.Value;
        }
    }
}
