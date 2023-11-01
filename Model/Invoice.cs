namespace Invoices.Model
{
    public class Invoice
    {
        public string Id { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public DateOnly DueDate { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public string ClientDetailsId { get; set; }
        public virtual ClientDetails ClientDetails { get; set; }
        public float TotalSum
        {
            get { return (float)Items.Sum(i => i.Product.Price * i.Quantity); }
        }
        public EStatus? Status { get; set; }
    }
}
