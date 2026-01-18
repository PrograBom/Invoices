namespace Invoices.Model;

public class Product : BaseModelEntity
{
    public Guid CompanyId { get; set; }  // FK na Company.Id

    public string Description { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal VatRate { get; set; }
    public string Unit { get; set; }  // "pcs", "hour", "service"

    // Navigation
    public virtual Company Company { get; set; }
    public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
}