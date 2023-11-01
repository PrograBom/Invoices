using System.ComponentModel.DataAnnotations;

namespace Invoices.Model
{
    public class Item
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
