using CallForPappersService_DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallForPappersService_DAL.Data.EntitiesConfiguration
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(
                new Activity { Type = ActivityType.Report, Description = "Доклад, 35-45 минут" },
                new Activity { Type = ActivityType.Discussion, Description = "Дискуссия / круглый стол, 40-50 минут" },
                new Activity { Type = ActivityType.MasterClass, Description = "Мастеркласс, 1-2 часа" });

            builder.HasKey(x => x.Type);
        }
    }
}
