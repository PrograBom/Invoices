namespace Invoices.Model;

public class Company : BaseModelEntity
{
    public string Name { get; set; }
    public string VatId { get; set; } // IC DPH
    public string TaxId { get; set; } // danove IC
    public string RegisterId { get; set; } // ICO
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Slug { get; set; }

    //Navigation
    public ICollection<Address> Addresses { get; set; }
    public ICollection<BankAccount> BankAccounts { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<InvoiceTemplate> InvoiceTemplates { get; set; }

}
