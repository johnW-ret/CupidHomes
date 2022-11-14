namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SalespersonConfig : IEntityTypeConfiguration<Salesperson>
{
    public void Configure(EntityTypeBuilder<Salesperson> builder)
    {
        builder.Property(s => s.Id);

        builder
            .Property(s => s.FirstName)
            .HasMaxLength(FieldConstants.NameFieldMaxLength);
        builder
            .Property(s => s.LastName)
            .HasMaxLength(FieldConstants.NameFieldMaxLength);

        builder.Property(s => s.DateOfBirth);
        builder.Property(s => s.Commission);
        
        /*builder
            .ToTable(b => b.HasCheckConstraint("CK_CommissionBounds", $"[{nameof(Salesperson.Commission)}] >= 0 and [{nameof(Salesperson.Commission)}] <= 1"));*/

        builder
            .HasMany(c => c.Sales)
            .WithOne(s => s.Salesperson);
    }
}