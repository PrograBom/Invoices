using Invoices.Model;

namespace Invoices.Dtos
{
    public class InvoiceDto
    {
        public string Id { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public DateOnly DueDate { get; set; }
        public ICollection<Item> Items { get; set; }
        public int ClientId { get; set; }
        public ClientDetails ClientDetails { get; set; }
    }
}
