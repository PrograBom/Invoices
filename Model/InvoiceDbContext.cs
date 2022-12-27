using Microsoft.EntityFrameworkCore;

namespace Invoices.Model;

public class InvoiceDbContext : DbContext
{
    //pre istotu bezparametrový aj parametrový konštruktor
    public InvoiceDbContext()
    {

    }
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options) { }

    //každá trieda má zápis v DbContext na tvorbu tabuľky
    public DbSet<Client> Client { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Invoice> Invoice { get; set; }

    //podmienky pre tvorbu tabuľky
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //môžem vytvoriť tabuľku s požadovaným typom stĺpca
        modelBuilder.Entity<Invoice>(e => e.Property(o => o.IssueDate).HasColumnType("DATE")
    }
}
