namespace ArmyTechTask.UI.Models.Invoice;

public class InvoiceHeaderVm
{
    public long Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime Invoicedate { get; set; }
    public int? CashierId { get; set; }
    public int BranchId { get; set; }
}