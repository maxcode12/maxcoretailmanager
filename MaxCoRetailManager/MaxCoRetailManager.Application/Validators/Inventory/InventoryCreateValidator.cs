using FluentValidation;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;

namespace MaxCoRetailManager.Application.Validators.Inventory;

public class InventoryCreateValidator : AbstractValidator<InventoryCreateDto>
{
    private readonly IInventoryRepository _inventoryRepository;
    public InventoryCreateValidator(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;

        RuleFor(p => p.ProductId)
            .GreaterThan(0).WithMessage("Product Id must be greater than 0.")
            .NotEmpty().WithMessage("Product Id is required.")
            .NotNull();

        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .NotNull()
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage("Date is required.")
            .NotNull();

        RuleFor(p => p.Cost)
            .GreaterThan(0).WithMessage("Cost must be greater than 0.")
            .NotEmpty().WithMessage("Cost is required.")
            .NotNull();
    }
}
