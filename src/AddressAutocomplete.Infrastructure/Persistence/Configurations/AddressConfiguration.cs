using AddressAutocomplete.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressAutocomplete.Infrastructure.Persistence.Configurations;

public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Street)
            .HasColumnName("street")
            .HasMaxLength(200);

        builder.Property(x => x.Number)
            .HasColumnName("number")
            .HasMaxLength(20);

        builder.Property(x => x.Neighborhood)
            .HasColumnName("neighborhood")
            .HasMaxLength(150);

        builder.Property(x => x.Complement)
            .HasColumnName("complement")
            .HasMaxLength(200);

        builder.Property(x => x.Municipality)
            .HasColumnName("municipality")
            .HasMaxLength(150);

        builder.Property(x => x.State)
            .HasColumnName("state")
            .HasMaxLength(100);

        builder.Property(x => x.PostalCode)
            .HasColumnName("postal_code")
            .HasMaxLength(20);

        builder.Property(x => x.Latitude)
            .HasColumnName("latitude");

        builder.Property(x => x.Longitude)
            .HasColumnName("longitude");

        builder.Property(x => x.FormattedAddress)
            .HasColumnName("formatted_address")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
    }
}