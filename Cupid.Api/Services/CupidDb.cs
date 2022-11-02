using Microsoft.EntityFrameworkCore;
using Cupid.Models;

namespace Cupid.Api;

public class CupidDb : DbContext
{
    public CupidDb(DbContextOptions<CupidDb> options)
        : base(options) { }
    // public DbSet<T> TSet => Set<T>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //new TEntityTypeConfiguration().Configure(modelBuilder.Entity<T>());
    }
}