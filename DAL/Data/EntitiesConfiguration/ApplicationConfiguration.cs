using CallForPappersService_DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallForPappersService_DAL.Data.EntitiesConfiguration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Navigation(x => x.Activity).AutoInclude();

            builder.HasIndex(a => a.AuthorId);
            builder.HasIndex(a => a.Status);

            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Outline).HasMaxLength(1000);
            builder.Property(x => x.AuthorId).IsRequired();
        }
    }
}