// <auto-generated />
using System;
using Files.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Files.Infrastructure.Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220126071957_SpecifyIdTypesWithConventions")]
    partial class SpecifyIdTypesWithConventions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Files.Domain.Entities.FileMetadata", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<byte[]>("CipherHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("CipherSize")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("char(36)")
                        .IsFixedLength();

                    b.Property<string>("CreatedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("char(36)")
                        .IsFixedLength();

                    b.Property<string>("DeletedByDevice")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<byte[]>("EncryptedProperties")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("char(36)")
                        .IsFixedLength();

                    b.Property<string>("ModifiedByDevice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<string>("Owner")
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("char(36)")
                        .IsFixedLength();

                    b.Property<byte[]>("OwnerSignature")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("FileMetadata");
                });
#pragma warning restore 612, 618
        }
    }
}
