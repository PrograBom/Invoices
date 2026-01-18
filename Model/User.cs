using Invoices.Enums;

namespace Invoices.Model;

public class User : BaseModelEntity
{
    public Guid CompanyId { get; set; }  // FK na Company.Id
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public EUserRole Role { get; set; }  // "Owner", "Admin", "Accountant", "Viewer"
    public bool IsActive { get; set; }

    // Navigation
    public virtual Company Company { get; set; }
}