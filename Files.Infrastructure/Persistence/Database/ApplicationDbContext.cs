using Enmeshed.BuildingBlocks.Infrastructure.Persistence.Database;
using Files.Domain.Entities;
using Files.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Files.Infrastructure.Persistence.Database
{
    public class ApplicationDbContext : AbstractDbContextBase
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<FileMetadata> FileMetadata { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.UseValueConverter(new FileIdEntityFrameworkValueConverter(new ConverterMappingHints(FileId.MAX_LENGTH)));

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
