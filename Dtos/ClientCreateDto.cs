using System.ComponentModel.DataAnnotations;

namespace Invoices.Dtos
{
    public class ClientCreateDto
    {
        [Required]
        [StringLength(8)]
        public string ClientId { get; set; }
        public int TaxId { get; set; }
        public int VatId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankNumber { get; set; }
    }
}
