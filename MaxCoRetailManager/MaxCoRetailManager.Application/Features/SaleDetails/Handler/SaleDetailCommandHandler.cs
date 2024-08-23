using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Features.SaleDetails.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Handler;

public class SaleDetailCommandHandler : IRequestHandler<CreateSaleDetailCommand, SaleDetailCreateDto>
{
    private readonly IMapper _mapper;
    private readonly ISaleDetailRepository _saleDetailRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IAuthRepository _authRepository;


    public SaleDetailCommandHandler(
        ISaleDetailRepository saleDetailRepository,
        IMapper mapper,
        ISaleRepository saleRepository,
        IProductRepository productRepository,
        IAuthRepository authRepository
        )
    {
        _authRepository = authRepository;
        _productRepository = productRepository;
        _saleRepository = saleRepository;

        _mapper = mapper;
        _saleDetailRepository = saleDetailRepository;
    }
    public async Task<SaleDetailCreateDto> Handle(CreateSaleDetailCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _authRepository.GetCurrentUserId();
        var userId = request.SaleDetailCreateDto.UserId = currentUser.ToString();

        if (request.SaleDetailCreateDto == null) throw new ArgumentNullException(nameof(request.SaleDetailCreateDto));

        var findProduct = await _productRepository.GetAllAsync(u => u.UserId == userId);
        var productId = findProduct.FirstOrDefault(x => x.Id == request.SaleDetailCreateDto.ProductId);
        if (productId == null) throw new Exception("Product not found");

        var findSale = await _saleRepository.GetAllAsync(u => u.UserId == userId);

        var saleId = findSale.FirstOrDefault(x => x.Id == request.SaleDetailCreateDto.SaleId);
        if (saleId == null) throw new Exception("Sale not found");

        var saleDetail = new SaleDetail
        {
            UserId = userId,
            SaleId = request.SaleDetailCreateDto.SaleId,
            ProductId = request.SaleDetailCreateDto.ProductId,
            Quantity = request.SaleDetailCreateDto.Quantity,
            PurchasePrice = request.SaleDetailCreateDto.PurchasePrice,
            Tax = request.SaleDetailCreateDto.Tax,
            SaleDate = request.SaleDetailCreateDto.SaleDate
        };

        var addSaleDetail = _saleDetailRepository.AddAsync(saleDetail);


        if (saleDetail == null)
        {
            throw new ApplicationException("SaleDetail cannot be created");
        }

        var saleDetailCreateDto = _mapper.Map<SaleDetailCreateDto>(saleDetail);
        return saleDetailCreateDto;
    }
}
