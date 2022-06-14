using ArmyTechTask.Core.Entities;

namespace ArmyTechTask.Core.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<InvoiceDetail> InvoiceDetail { get; }
    IBaseRepository<InvoiceHeader> InvoiceHeader { get; }
    IBaseRepository<Branch> Branch { get; }
    IBaseRepository<City> City { get; }
    IBaseRepository<Cashier> Cashier { get; }
    int Complete();
}