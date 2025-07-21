using Application.Interface;
using Application.Interfaces.Specific.IunitOW;
using Infrastructure.ADbContext;


namespace Infrastructure.Repository.GenericRepo
{
    public class OrderUnitOfWork(IOrderRepository orderRepository, IInvoiceRepository invoiceRepository,
        IPurchaseRepository purchaseRepository, ISaleRepository saleRepository
        ,IInventoryRepository inventoryRepository,AppDbContext appDbContext ) : IOrderUnitOfWork
    {

        private readonly AppDbContext _appDbContext = appDbContext;
        public IOrderRepository OrderRepository => orderRepository;

        public IInvoiceRepository InvoiceRepository => invoiceRepository;

        public IPurchaseRepository PurchaseRepository => purchaseRepository;

        public ISaleRepository SaleRepository => saleRepository;

        public IInventoryRepository InventoryRepository => inventoryRepository;

        public void Dispose() => _appDbContext.Dispose();


        public async Task<int> SaveAsync() => await _appDbContext.SaveChangesAsync();
       
    }
}
