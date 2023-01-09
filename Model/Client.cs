using System.ComponentModel.DataAnnotations;

namespace Invoices.Model
{
    public class Client
    {
        public string ClientId { get; set; }
        public int TaxId { get; set; }
        public int VatId { get; set; }
        public string Name { get; set; }

        //nastavenie varchar(100)
        [StringLength(100)]
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankNumber { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
