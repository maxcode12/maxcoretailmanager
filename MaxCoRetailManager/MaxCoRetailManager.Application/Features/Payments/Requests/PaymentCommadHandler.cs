using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.PaymentDTO;
using MaxCoRetailManager.Application.Features.Payments.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Payments.Requests;

public class PaymentCommadHandler : IRequestHandler<PaymentCommand, PaymentCreateDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ISaleDetailRepository _saleDetailRepository;
    private readonly IAuthRepository _authenticate;
    private readonly IMapper _mapper;

    public PaymentCommadHandler(IPaymentRepository paymentRepository,
        ISaleDetailRepository saleDetailRepository,
        IAuthRepository authenticate,
        IMapper mapper)
    {
        _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
        _saleDetailRepository = saleDetailRepository ?? throw new ArgumentNullException(nameof(saleDetailRepository));
        _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PaymentCreateDto> Handle(PaymentCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _authenticate.GetCurrentUserId();
        var userId = request.ModelPayment.UserId = currentUser.ToString();

        if (request.ModelPayment == null) throw new ArgumentNullException(nameof(request.ModelPayment));

        var findSaleDetail = await _saleDetailRepository.GetAllAsync(u => u.UserId == userId);
        var saleDetailId = findSaleDetail.FirstOrDefault(x => x.Id == request.ModelPayment.SaleDetailId);
        if (saleDetailId == null) throw new Exception("Sale Detail not found");

        var payment = new Payment
        {
            SaleDetailId = request.ModelPayment.SaleDetailId,
            PaymentDate = request.ModelPayment.PaymentDate,
            Amount = request.ModelPayment.Amount,
            PaymentMethod = request.ModelPayment.PaymentMethod,
            UserId = userId
        };

        await _paymentRepository.AddAsync(payment);

        return _mapper.Map<PaymentCreateDto>(payment);
    }

}
