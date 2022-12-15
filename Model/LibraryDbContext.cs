using Microsoft.EntityFrameworkCore;

namespace Invoices.Model;

public class LibraryDbContext : DbContext
{

    public LibraryDbContext()
    {

    }
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Items> Items { get; set; }
}
