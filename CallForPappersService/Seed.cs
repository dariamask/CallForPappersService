using CallForPappersService.Data;
using CallForPappersService.Data.Entities;


namespace CallForPappersService
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            this._context = context;
        }
        public void SeedDataContext()
        {
            if (!_context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                    Id = Guid.NewGuid(),
                    ActivityType = ActivityType.Report,
                    Description = "Доклад, 35-45 минут",
                    },

                    new Activity
                    {
                    Id = Guid.NewGuid(),
                    ActivityType = ActivityType.Discussion,
                    Description = "Дискуссия / круглый стол, 40-50 минут",
                    },

                    new Activity
                    {
                    Id = Guid.NewGuid(),
                    ActivityType = ActivityType.MasterClass,
                    Description = "Мастеркласс, 1-2 часа",
                    },
                };
                     
                _context.Activities.AddRange(activities);
                _context.SaveChanges();
            }
        }
    }
}
