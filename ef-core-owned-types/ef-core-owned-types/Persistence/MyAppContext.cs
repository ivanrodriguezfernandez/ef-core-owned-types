using ef_core_owned_types.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef_core_owned_types.Persistence
{

    public class MyAppContext : DbContext
    {

        public MyAppContext(DbContextOptions<MyAppContext> options) :
            base(options)
        {
        }

        public MyAppContext()
        {
        }

        public DbSet<Dashboard> Dashboard { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=NetCore2019;Trusted_Connection=True;MultipleActiveResultSets=true");

                var loggerFactory = new LoggerFactory();
                //loggerFactory.AddConsole();
                optionsBuilder.UseLoggerFactory(loggerFactory);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dashboard>().HasKey(o => o.Id);

            modelBuilder.Entity<Dashboard>().OwnsMany(p => p.DashboardItems, dashboardItemsBuilder =>
            {
                dashboardItemsBuilder.HasForeignKey("DashboardId");

                dashboardItemsBuilder.OwnsOne(e => e.Size, size =>
                {
                    size.Property(e => e.Height).HasColumnName("SizeHeight");
                    size.Property(e => e.Width).HasColumnName("SizeWidth");
                });

                dashboardItemsBuilder.OwnsOne(e => e.Position, position =>
                {
                    position.Property(e => e.X).HasColumnName("Position_X");
                    position.Property(e => e.Y).HasColumnName("Position_Y");
                });

                dashboardItemsBuilder.HasKey("DashboardId", "AppViewId");
                //dashboardItemsBuilder.HasKey("DashboardId","AppViewId","PositionX","PositionY", "Height", "Width");
                //dashboardItemsBuilder.HasKey("DashboardId", "AppViewId", "Size_Height", "Size_Width", "Position_X", "Position_Y");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}