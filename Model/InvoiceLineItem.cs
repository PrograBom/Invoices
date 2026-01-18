using System.ComponentModel.DataAnnotations;

namespace Invoices.Model;

public class InvoiceLineItem : BaseModelEntity
{
    public Guid CompanyId { get; set; }  // FK na Company.Id
    public Guid InvoiceId { get; set; }  // FK na Invoice.Id
    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal VatRate { get; set; }
    public Guid? ProductId { get; set; }  // FK na Product.Id (nullable)
                                           // Navigation
    public virtual Invoice Invoice { get; set; }
    public virtual Product Product { get; set; }

    public decimal Amount
    {
        get { return (Quantity * UnitPrice) * (1 + VatRate / 100); }
    }
    public decimal TotalLineAmount { get; set; }
}
