namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SaleNoteConfig : IEntityTypeConfiguration<SaleNote>
{
    public void Configure(EntityTypeBuilder<SaleNote> builder)
    {
        builder.HasKey(s => new { s.SaleId, s.CreatedOn });

        builder.Property(s => s.SaleId);
        builder
            .HasOne(s => s.Sale)
            .WithMany(s => s.Notes);

        builder
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getutcdate()");
        builder.Property(s => s.Notes);
    }
}