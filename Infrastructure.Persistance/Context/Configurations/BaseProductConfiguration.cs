using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Context.Configurations;

internal class BaseProductConfiguration : IEntityTypeConfiguration<BaseProduct>
{
    public void Configure(EntityTypeBuilder<BaseProduct> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne<Brand>(p => p.Brand)
            .WithMany(b => b.BaseProducts)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
