namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SaleConfig : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.Property(s => s.Id);

        builder.Property(s => s.HouseId);
        builder
            .HasOne(s => s.House);

        builder.Property(s => s.SalespersonId);
        builder
            .HasOne(s => s.Salesperson)
            .WithMany(s => s.Sales);

        builder.Property(s => s.CustomerId);
        builder
            .HasOne(s => s.Customer)
            .WithMany(c => c.Sales)
            .IsRequired();

        builder.Property(s => s.ClosedOn);
        builder.Property(s => s.Budget);
        builder.Property(s => s.Price);
    }
}