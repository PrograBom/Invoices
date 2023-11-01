using Invoices.Model;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public EUserType UserType { get; set; }
    public string Address { get; set; }
    public string BankNumber { get; set; }

    // Navigation properties
    public ClientDetails ClientDetails { get; set; }
    public Invoice Invoice { get; set; }
}