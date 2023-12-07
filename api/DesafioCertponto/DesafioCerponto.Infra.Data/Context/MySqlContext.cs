using DesafioCerponto.Infra.Data.Mapping;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DesafioCerponto.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }
        public static IConfiguration Configuration { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Votacao> Votacoes { get; set; }

        public DbSet<RestauranteVencedor> RestaurantesVencedor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));
            optionsBuilder.UseMySql(GetConnectionString(), serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profissional>(new ProfissionalMap().Configure);
            modelBuilder.Entity<Restaurante>(new RestauranteMap().Configure);
            modelBuilder.Entity<Votacao>(new VotacaoMap().Configure);
            modelBuilder.Entity<RestauranteVencedor>(new RestauranteVencedorMap().Configure);
        }
        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }
    }
}
