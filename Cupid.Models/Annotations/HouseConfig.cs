namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HouseConfig : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.Property(h => h.Id);
        
        builder.Property(h => h.PlanNumber);
        builder
            .HasOne(h => h.Plan);

        builder.Property(h => h.LotNumber);
        builder.Property(h => h.BlockNumber);
        builder.Property(h => h.Notes);
        builder.Property(h => h.MarketValue);
        builder.Property(h => h.IsAvailable);
        builder.Property(h => h.ClosedOn);
    }
}