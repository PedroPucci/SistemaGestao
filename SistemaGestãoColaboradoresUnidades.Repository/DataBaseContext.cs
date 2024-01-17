using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaGestãoColaboradoresUnidades.Domain;

namespace SistemaGestãoColaboradoresUnidades.Repository
{
    public class DataBaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataBaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<UnityEntity> UnityEntity { get; set; }
        public DbSet<CollaboratorEntity> CollaboratorEntity { get; set; }
    }
}