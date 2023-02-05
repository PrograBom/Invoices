using Invoices.Model;
using System.Net;

namespace Invoices.Dtos
{
    public class CreateInvoiceDto
    {
        public int Id { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public DateOnly DueDate { get; set; }
        public virtual ICollection<InvoiceItem> Items { get; set; }
        public virtual Client Client { get; set; }
    }
}
