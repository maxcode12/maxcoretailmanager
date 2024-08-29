using FluentValidation;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;

namespace MaxCoRetailManager.Application.Validators.Inventory;

public class InventoryUpdateValidator : AbstractValidator<InventoryUpdateDto>
{
    private readonly IInventoryRepository _inventoryRepository;
    public InventoryUpdateValidator(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;

        RuleFor(p => p.Id)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0).WithMessage("Id must be greater than 0.")
            .MustAsync(async (id, token) =>
            {
                return await _inventoryRepository.IsExist(id);
            }).WithMessage("Inventory does not exist.");


        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("Product Id is required.")
            .NotNull();

        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .NotNull()
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        RuleFor(p => p.Cost)
            .GreaterThan(0).WithMessage("Cost must be greater than 0.")
            .NotEmpty().WithMessage("Cost is required.")
            .NotNull();

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage("Date is required.")
            .NotNull();

        RuleFor(p => p.LocationId)
            .NotEmpty().WithMessage("Location Id is required.")
            .NotNull()
            .GreaterThan(0).WithMessage("Location Id must be greater than 0.");

    }
}
