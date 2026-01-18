namespace Invoices.Model;

public class BankAccount : BaseModelEntity
{
    public Guid CompanyId { get; set; }  // FK na Company.Id

    public string IBAN { get; set; }
    public string BIC { get; set; }
    public string SWIFT { get; set; }
    public string AccountHolder { get; set; }

    // Navigation
    public virtual Company Company { get; set; }
}
