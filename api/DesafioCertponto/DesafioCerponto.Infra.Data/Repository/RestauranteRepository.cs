using DesafioCerponto.Infra.Data.Context;
using DesafioCerponto.Infra.Data.Repository;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Interfaces.Repositories;

namespace DesafioCertponto.Infra.Data.Repository
{
    public class RestauranteRepository : BaseRepository<Restaurante>, IRestauranteRepository
    {
        private readonly MySqlContext _context;
        public RestauranteRepository(MySqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

    }

}
