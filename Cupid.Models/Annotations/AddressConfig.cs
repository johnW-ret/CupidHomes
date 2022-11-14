namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(h => h.Id);
        builder.Property(h => h.AddressLine1);
        builder.Property(h => h.AddressLine2);
        builder.Property(h => h.City);
        builder.Property(h => h.State);
        builder.Property(h => h.Zip);
    }
}