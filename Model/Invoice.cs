namespace Invoices.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public DateOnly DueDate { get; set; }
        public virtual ICollection<Items> Items { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
