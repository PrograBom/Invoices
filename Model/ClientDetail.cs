using Invoices.Model;

namespace Invoices.Model
{
    public class ClientDetail
    {
        public int Id { get; set; }
        public string TaxId { get; set; }
        public string VatId { get; set; }

        public int InvoiceId { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}