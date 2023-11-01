using Microsoft.EntityFrameworkCore;

namespace Invoices.Model;

public class ApplicationDbContext : DbContext
{
    //pre istotu bezparametrový aj parametrový konštruktor
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //každá trieda má zápis v DbContext na tvorbu tabuľky
    public DbSet<Item> Items { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ClientDetails> ClientDetails { get; set; }


    //podmienky pre tvorbu tabuľky
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //môžem vytvoriť tabuľku s požadovaným typom stĺpca
        modelBuilder.Entity<Invoice>(e => e.Property(o => o.IssueDate).HasColumnType("DATE"));
    }
}
