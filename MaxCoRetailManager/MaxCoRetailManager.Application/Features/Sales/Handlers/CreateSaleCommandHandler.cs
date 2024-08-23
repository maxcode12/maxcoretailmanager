using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Features.Sales.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Handlers;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, SaleCreateDto>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IAuthRepository _authRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public CreateSaleCommandHandler(
        ISaleRepository saleRepository,
        IAuthRepository authRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _authRepository = authRepository;
        _productRepository = productRepository;
        _saleRepository = saleRepository;
        _mapper = mapper;

    }
    public async Task<SaleCreateDto> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var user = _authRepository.GetCurrentUserId();
        var userId = request.SaleCreateDto.SaleBy = user.ToString();

        var productId = await _productRepository.GetAllAsync(p => p.UserId == userId);
        var product = productId.FirstOrDefault(x => x.Id == request.SaleCreateDto.ProductId);
        if (product == null) throw new Exception("Product not found");



        var sale = new Sale
        {
            UserId = userId,
            ProductId = request.SaleCreateDto.ProductId,
            PurchasePrice = request.SaleCreateDto.PurchasePrice,
            Quantity = request.SaleCreateDto.Quantity,
            SubTotal = request.SaleCreateDto.SubTotal,
            Tax = request.SaleCreateDto.Tax,
            Total = request.SaleCreateDto.Total,
            SaleDate = request.SaleCreateDto.SaleDate

        };
        await _saleRepository.AddAsync(sale);

        var saleMap = _mapper.Map<Sale>(request.SaleCreateDto);

        var saleMapped = _mapper.Map<SaleCreateDto>(saleMap);
        return saleMapped;

    }
}
