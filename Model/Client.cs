using System.ComponentModel.DataAnnotations;

namespace Invoices.Model
{
    public class Client
    {
        public int Id { get; set; }

        public int TaxId { get; set; }
        public int VatId { get; set; }
        public string Name { get; set; }

        //nastavenie varchar(100)
        [StringLength(100)]
        public string Address { get; set; }
        public int BankNumber { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
