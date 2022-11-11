using Microsoft.EntityFrameworkCore;

namespace Cupid.Models;

public class CupidDb : DbContext
{
    public CupidDb(DbContextOptions<CupidDb> options)
        : base(options) { }
    public DbSet<Customer> Games => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new CustomerConfig().Configure(modelBuilder.Entity<Customer>());
    }
}
