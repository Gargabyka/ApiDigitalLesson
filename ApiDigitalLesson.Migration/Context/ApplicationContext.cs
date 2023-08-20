using ApiDigitalLesson.Migration.Configuration;
using AspDigitalLesson.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiDigitalLesson.Migration.Context
{
    /// <summary>
    /// Контекст сущностей
    /// </summary>
    public class ApplicationContext: DbContext
    {
        private readonly IConfigurationRoot _config;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfigurationRoot configuration) : base(options)
        {
            _config = configuration;
        }

        public DbSet<AboutTeacher> AboutTeacher { get; set; }
        public DbSet<GroupLesson> GroupLesson { get; set; }
        public DbSet<GroupLessonStudents> GroupLessonStudents { get; set; }
        public DbSet<SingleLesson> SingleLesson { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherTypeLesson> TeacherTypeLesson { get; set; }
        public DbSet<TypeLessons> TypeLessons { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }
        public DbSet<SettingsStudent> SettingsStudent { get; set; }
        public DbSet<SettingsTeacher> SettingsTeacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_config["ConnectionStrings:DefaultConnection"],
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypeLessonConfiguration());
            
            modelBuilder.Entity<TeacherTypeLesson>()
                .HasOne(p => p.Teacher)
                .WithOne()
                .HasForeignKey<TeacherTypeLesson>(p => p.TeacherId);
        }
    }
}
