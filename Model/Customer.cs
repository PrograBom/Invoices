namespace Invoices.Model;

public class Customer : BaseModelEntity
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string RegistrationNumber { get; set; } // IČO
    public string TaxId { get; set; } // DIČ
    public string VatNumber { get; set; } // IČ DPH

    public virtual Company Company { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
}
