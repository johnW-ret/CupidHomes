namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SalespersonConfig : IEntityTypeConfiguration<Salesperson>
{
    public void Configure(EntityTypeBuilder<Salesperson> builder)
    {
        builder.Property(s => s.Id);
        builder.Property(s => s.FirstName);
        builder.Property(s => s.LastName);
        builder.Property(s => s.DateOfBirth);
        builder.Property(s => s.Commission);

        builder
            .HasMany(c => c.Sales)
            .WithOne(s => s.Salesperson);
    }
}