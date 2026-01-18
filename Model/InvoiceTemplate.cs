using Invoices.Enums;

namespace Invoices.Model;

public class InvoiceTemplate : BaseModelEntity
{
    public Guid CompanyId { get; set; }  // FK na Company.Id
    public string Name { get; set; }

    public Guid? CustomerId { get; set; }  // FK (nullable)
    public EFrequencyType FrequencyType { get; set; }  // "Monthly", "Quarterly", "Yearly"

    public DateTime NextGenerationDate { get; set; }
    public bool IsActive { get; set; }

    // Navigation
    public virtual Company Company { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<InvoiceTemplateItem> TemplateItems { get; set; }
}
