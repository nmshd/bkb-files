using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using Files.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Files.Infrastructure.Persistence.Database.EntityTypeConfigurations;

public class FileMetadataEntityTypeConfiguration : IEntityTypeConfiguration<FileMetadata>
{
    public void Configure(EntityTypeBuilder<FileMetadata> builder)
    {
        builder.HasIndex(m => m.CreatedBy);

        builder.Property(x => x.Id).HasColumnType($"char({FileId.MAX_LENGTH})");
        builder.Property(x => x.CreatedBy).HasColumnType($"char({IdentityAddress.MAX_LENGTH})");
        builder.Property(x => x.CreatedByDevice).HasColumnType($"char({DeviceId.MAX_LENGTH})");
        builder.Property(x => x.DeletedBy).HasColumnType($"char({IdentityAddress.MAX_LENGTH})");
        builder.Property(x => x.DeletedByDevice).HasColumnType($"char({DeviceId.MAX_LENGTH})");
        builder.Property(x => x.ModifiedBy).HasColumnType($"char({IdentityAddress.MAX_LENGTH})");
        builder.Property(x => x.ModifiedByDevice).HasColumnType($"char({DeviceId.MAX_LENGTH})");
        builder.Property(x => x.Owner).HasColumnType($"char({IdentityAddress.MAX_LENGTH})");

        builder.Property(m => m.CipherHash).IsRequired();
    }
}
