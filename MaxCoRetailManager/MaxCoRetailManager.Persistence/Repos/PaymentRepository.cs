using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Core.Entities;
using MaxCoRetailManager.Persistence.Data;

namespace MaxCoRetailManager.Persistence.Repos
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(MaxCoRetailDbContext context) : base(context)
        {
        }
    }
}
