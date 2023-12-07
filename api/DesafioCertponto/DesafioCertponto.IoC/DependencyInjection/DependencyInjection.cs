using DesafioCerponto.Infra.Data.Context;
using DesafioCerponto.Infra.Data.Repository;
using DesafioCertponto.Domain.Interfaces.Repositories;
using DesafioCertponto.Domain.Interfaces.Services;
using DesafioCertponto.Infra.Data.Repository;
using DesafioCertponto.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioCertponto.IoC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddDependency(this IServiceCollection services)
        {

            services.AddDbContext<MySqlContext>();

            services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
            services.AddScoped<IServiceProfissional, ProfissionalService>();

            services.AddScoped<IServiceRestaurante, RestauranteService>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();

            services.AddScoped<IServiceVotacao, VotacaoService>();
            services.AddScoped<IVotacaoRepository, VotacaoRepository>();

            services.AddScoped<IRestauranteVencedorRepository, RestauranteVencedorRepository>();
        }
    }
}
