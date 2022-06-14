using ArmyTechTask.Core.Entities;

namespace ArmyTechTask.UI.Models.Invoice;

public class IndexVM
{
    public IEnumerable<InvoiceDetailsVm>? InvoiceDetailsVm { get; set; }
    public IEnumerable<InvoiceHeaderVm>? InvoiceHeaderVm { get; set; }
}