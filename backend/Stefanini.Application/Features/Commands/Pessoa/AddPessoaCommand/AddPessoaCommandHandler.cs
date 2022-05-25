using AutoMapper;
using MediatR;
using Stefanini.Application.Contracts.Persistence;
using Stefanini.Domain.Entities;

namespace Stefanini.Application.Features.Commands.AddPessoaCommand
{
    public class AddPessoaCommandHandler : IRequestHandler<AddPessoaCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public AddPessoaCommandHandler(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(AddPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoaToAdd = new Pessoa();
            _mapper.Map(request, pessoaToAdd, typeof(AddPessoaCommand), typeof(Pessoa));

            await _pessoaRepository.AddAsync(pessoaToAdd);

            return Unit.Value;
        }
    }
}
