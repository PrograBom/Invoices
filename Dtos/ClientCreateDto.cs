namespace Invoices.Dtos
{
    public class ClientCreateDto
    {
        public int ClientId { get; set; }
        public string TaxId { get; set; }
        public string VatId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankNumber { get; set; }
    }
}
