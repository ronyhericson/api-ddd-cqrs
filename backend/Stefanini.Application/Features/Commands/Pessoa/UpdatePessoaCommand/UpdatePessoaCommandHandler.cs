using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Application.Exceptions;
using Stefanini.Domain.Entities;

namespace Stefanini.Application.Features.Commands.UpdatePessoaCommand
{
    public class UpdatePessoaCommandHandler : IRequestHandler<UpdatePessoaCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public UpdatePessoaCommandHandler(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdatePessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoaToUpdate = await _pessoaRepository.GetByIdAsync(request.Id);
            if (pessoaToUpdate == null)
            {
                throw new NotFoundException(nameof(Pessoa), request.Id);
            }
            _mapper.Map(request, pessoaToUpdate, typeof(UpdatePessoaCommand), typeof(Pessoa));

            await _pessoaRepository.UpdateAsync(pessoaToUpdate);

            return Unit.Value;
        }
    }
}
