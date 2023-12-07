
using DesafioCerponto.Infra.Data.Context;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Interfaces.Repositories;

namespace DesafioCerponto.Infra.Data.Repository
{
    public class ProfissionalRepository : BaseRepository<Profissional>, IProfissionalRepository
    {
        private readonly MySqlContext _context;
        public ProfissionalRepository(MySqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
