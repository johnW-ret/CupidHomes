using Microsoft.EntityFrameworkCore;

namespace Cupid.Models;
using Cupid.Models.Annotations;

public class CupidDb : DbContext
{
    public CupidDb(DbContextOptions<CupidDb> options)
        : base(options) { }
    public DbSet<Customer> Customer => Set<Customer>();
    public DbSet<House> House => Set<House>();
    public DbSet<Plan> Plan => Set<Plan>();
    public DbSet<Sale> Sale => Set<Sale>();
    public DbSet<Salesperson> Salesperson => Set<Salesperson>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new CustomerConfig().Configure(modelBuilder.Entity<Customer>());
        new HouseConfig().Configure(modelBuilder.Entity<House>());
        new PlanConfig().Configure(modelBuilder.Entity<Plan>());
        new SaleConfig().Configure(modelBuilder.Entity<Sale>());
        new SalespersonConfig().Configure(modelBuilder.Entity<Salesperson>());
    }
}
