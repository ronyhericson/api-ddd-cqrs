using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Application.Exceptions;

namespace Stefanini.Application.Features.Commands.Cidade.UpdateCidadeCommand
{
    public class UpdateCidadeCommandHandler : IRequestHandler<UpdateCidadeCommand>
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public UpdateCidadeCommandHandler(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository ?? throw new ArgumentNullException(nameof(cidadeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Unit> Handle(UpdateCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidadeToUpdate = await _cidadeRepository.GetByIdAsync(request.Id);
            if (cidadeToUpdate == null)
            {
                throw new NotFoundException(nameof(Cidade), request.Id);
            }
            _mapper.Map(request, cidadeToUpdate, typeof(UpdateCidadeCommand), typeof(Stefanini.Domain.Entities.Cidade));

            await _cidadeRepository.UpdateAsync(cidadeToUpdate);

            return Unit.Value;
        }
    }
}
