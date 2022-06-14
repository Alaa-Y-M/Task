namespace ArmyTechTask.UI.Models.Invoice;

public class InvoiceDetailsVm
{
    public long Id { get; set; }
    public long InvoiceHeaderId { get; set; }
    public string ItemName { get; set; } = null!;
    public double ItemCount { get; set; }
    public double ItemPrice { get; set; }
}