using Invoices.Enums;

namespace Invoices.Model;

public class Address : BaseModelEntity
{
    public Guid? CompanyId { get; set; }
    public Guid? CustomerId { get; set; }

    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public EAddressType EAddressType { get; set; }
}
