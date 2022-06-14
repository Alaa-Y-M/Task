using ArmyTechTask.Core.Common.Interfaces;
using ArmyTechTask.Core.Entities;
using ArmyTechTask.Infrastructure.Data;

namespace ArmyTechTask.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IBaseRepository<InvoiceDetail> InvoiceDetail { get; private set; }
    public IBaseRepository<InvoiceHeader> InvoiceHeader { get; private set; }
    public IBaseRepository<Branch> Branch { get; private set; }
    public IBaseRepository<City> City { get; private set; }

    public IBaseRepository<Cashier> Cashier { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        InvoiceDetail = new BaseRepository<InvoiceDetail>(_context);
        InvoiceHeader = new BaseRepository<InvoiceHeader>(_context);
        Branch = new BaseRepository<Branch>(_context);
        City = new BaseRepository<City>(_context);
        Cashier = new BaseRepository<Cashier>(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}