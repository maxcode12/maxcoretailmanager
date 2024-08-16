using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.Features.Sales.Requests;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Commands
{
    internal class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommandRequest, Unit>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public DeleteSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteSaleCommandRequest request, CancellationToken cancellationToken)
        {
            var saleMapper = _mapper.Map<Sale>(request.SaleDeleteDto);
            await _saleRepository.DeleteAsync(saleMapper);
            return Unit.Value;
        }
    }
}
