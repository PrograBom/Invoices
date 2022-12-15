using System.ComponentModel.DataAnnotations;

namespace Invoices.Model
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
