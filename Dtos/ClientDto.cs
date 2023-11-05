using Invoices.Model;

namespace Invoices.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public int TaxId { get; set; }
        public int VatId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string BankNumber { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
