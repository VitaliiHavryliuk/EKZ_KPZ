using Microsoft.EntityFrameworkCore;
using DAL.ValueConverters;
using Domain.Entities;
using DAL.EntityConfigurations;

namespace DAL
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProjectTask> ProjectTasks  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntities(modelBuilder);
        }
        
        protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
        {
            modelBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            modelBuilder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectTaskConfiguration());
        }

    }
}
