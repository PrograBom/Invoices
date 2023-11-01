public class ClientDetails
{
    public string Id { get; set; }
    public string TaxId { get; set; }
    public string VatId { get; set; }

    // Foreign key
    public string UserId { get; set; }

    // Navigation property
    public User User { get; set; }
}