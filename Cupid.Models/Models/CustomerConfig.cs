namespace Cupid.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .Property(p => p.Id);

        builder
            .Property(p => p.FirstName);

        builder
            .Property(p => p.LastName);
    }
}