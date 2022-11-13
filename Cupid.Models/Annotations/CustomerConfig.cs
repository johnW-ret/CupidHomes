﻿namespace Cupid.Models.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(c => c.Id)
            .IsClustered();

        builder
            .HasAlternateKey(c => c.Email)
            .IsClustered(false);

        builder.Property(p => p.Id);
        builder.Property(p => p.FirstName);
        builder.Property(p => p.LastName);
        builder.Property(p => p.Notes);
        builder.Property(p => p.AnnualIncome);
        builder.Property(p => p.Phone);

        builder
            .HasMany(c => c.Plans)
            .WithMany(p => p.Customers);

        builder
            .HasMany(c => c.Sales)
            .WithOne(s => s.Customer);
    }
}