using ArmyTechTask.Core.Entities;

namespace ArmyTechTask.UI.Models.Invoice;

public class InvoiceVM
{
    public InvoiceDetailsVm? InvoiceDetailsVm { get; set; }
    public InvoiceHeaderVm? InvoiceHeaderVm { get; set; }
    public int CityId { get; set; }
    public int BranchId { get; set; }
    public int CashierId { get; set; }
    public List<Cashier>? Cashiers { get; set; }
    public List<Branch>? Branches { get; set; }
    public List<City>? Cities { get; set; }
}