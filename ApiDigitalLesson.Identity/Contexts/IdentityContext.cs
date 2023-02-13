using ApiDigitalLesson.Identity.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiDigitalLesson.Identity.Contexts
{
    /// <summary>
    /// Контекст авторизации/аутентификации
    /// </summary>
    public class IdentityContext : IdentityDbContext<UserIdentity, RoleIdentity, string>
    {
        private readonly IConfigurationRoot _config;
        public IdentityContext(DbContextOptions<IdentityContext> options, IConfigurationRoot configuration) : base(options)
        {
            _config = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<UserIdentity>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<RoleIdentity>(entity =>
            {
                entity.ToTable(name: "Role");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_config["ConnectionStrings:DefaultConnection"], 
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
        }
    }
}
