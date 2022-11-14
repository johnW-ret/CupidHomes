namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PlanConfig : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasKey(p => p.Number);

        builder.Property(s => s.Name);
        builder.Property(s => s.RetiredOn);

        builder
            .HasMany(p => p.Customers)
            .WithMany(c => c.Plans)
            .UsingEntity(join => join.ToTable(FieldConstants.CustomerPlanJoinTableName));
    }
}