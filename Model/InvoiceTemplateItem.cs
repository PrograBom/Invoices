namespace Invoices.Model;

public class InvoiceTemplateItem : BaseModelEntity
{
    public Guid CompanyId { get; set; }  // FK na Company.Id
    public Guid InvoiceTemplateId { get; set; }  // FK na InvoiceTemplate.Id

    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid? ProductId { get; set; }  // FK (nullable)

    // Navigation
    public virtual InvoiceTemplate InvoiceTemplate { get; set; }
    public virtual Product Product { get; set; }
}
