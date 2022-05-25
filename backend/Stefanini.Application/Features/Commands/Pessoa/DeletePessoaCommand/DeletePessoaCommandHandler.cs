using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Application.Exceptions;
using Stefanini.Domain.Entities;

namespace Stefanini.Application.Features.Commands.DeletePessoaCommand
{
    public class DeletePessoaCommandHandler : IRequestHandler<DeletePessoaCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public DeletePessoaCommandHandler(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(DeletePessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoaToDelete = await _pessoaRepository.GetByIdAsync(request.Id);
            if (pessoaToDelete == null)
            {
                throw new NotFoundException(nameof(Pessoa), request.Id);
            }

            await _pessoaRepository.DeleteAsync(pessoaToDelete);

            return Unit.Value;
        }
    }
}
