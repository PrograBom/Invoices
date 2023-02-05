using System.ComponentModel.DataAnnotations;

namespace Invoices.Model
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}
