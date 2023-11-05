using System.ComponentModel.DataAnnotations;

namespace Invoices.Model
{
    public class Item
    {
        public int Id { get; set; }
        public int InvoiceIds { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
