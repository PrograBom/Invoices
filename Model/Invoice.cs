using Invoices.Enums;

namespace Invoices.Model;

public class Invoice : BaseModelEntity
{
    public Guid CompanyId { get; set; } // Tenant
    public Guid CustomerId { get; set; } // Klient

    public string Number { get; set; } // "20250001"
    public int NumberValue { get; set; }
    public string VariableSymbol { get; set; }

    // SNAPSHOTY (Data v čase vystavenia)
    public string CustomerNameSnapshot { get; set; }
    public string CustomerAddressSnapshot { get; set; } // Alebo JSON
    public string CustomerVatIdSnapshot { get; set; }
    public string SupplierNameSnapshot { get; set; }
    public string SupplierAddressSnapshot { get; set; }
    public string SupplierIbanSnapshot { get; set; } // Veľmi dôležité!
    public string SupplierRegistrationSnapshot { get; set; } // "Zapísaná v OR..."

    public DateTime IssueDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime DueDate { get; set; }

    public string CurrencyCode { get; set; } = "EUR"; // "EUR"
    public decimal ExchangeRate { get; set; } = 1.0m;

    public EInvoiceStatus Status { get; set; }

    // Výsledné sumy uložené v DB (kvôli queryingu)
    public decimal TotalTaxBase { get; set; }
    public decimal TotalVatAmount { get; set; }
    public decimal TotalAmountWithVat { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Company Company { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<InvoiceLineItem> LineItems { get; set; }
}
