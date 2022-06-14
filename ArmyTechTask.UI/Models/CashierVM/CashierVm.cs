using ArmyTechTask.Core.Entities;

namespace ArmyTechTask.UI.Models.CashierVM;

public class CashierVm
{
    public int Id { get; set; }
    public string CashierName { get; set; } = null!;
    public int BranchId { get; set; }
    public List<InvoiceHeader>? InvoiceHeaders { get; set; }
}