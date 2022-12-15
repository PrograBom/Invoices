using System.ComponentModel.DataAnnotations;

namespace Invoices.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //nastavenie varchar(100)
        [StringLength(100)]
        public string Address { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
