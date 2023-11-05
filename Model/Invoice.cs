namespace Invoices.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DueDate { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int ClientDetailId { get; set; }
        public virtual ClientDetail ClientDetail { get; set; }
        public float TotalSum
        {
            get { return (float)Items.Sum(i => i.Product.Price * i.Quantity); }
        }
        public EStatus? Status { get; set; }
    }
}
