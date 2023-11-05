using Invoices.Enums;

namespace Invoices.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EUserType UserType { get; set; }
        public string Address { get; set; }
        public string BankNumber { get; set; }

        public int ClientDetailId { get; set; }
        // Navigation properties
        public ClientDetail ClientDetail { get; set; }
    }
}