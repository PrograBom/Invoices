using Invoices.Model;

namespace Invoices.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public DateOnly DueDate { get; set; }
        public ICollection<Items> Items { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
