using System.Globalization;
using DesafioCerponto.Infra.Data.Context;
using DesafioCerponto.Infra.Data.Repository;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioCertponto.Infra.Data.Repository
{
    public class VotacaoRepository : BaseRepository<Votacao>, IVotacaoRepository
    {
        private readonly MySqlContext _context;

        public VotacaoRepository(MySqlContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Profissional> ProfissionalThatDidntVote(DateTime dataVotacao)
        {

            List<Profissional> todosProfissionais = _context.Profissionais.ToList();
    
            List<int> profissionaisQueVotaramIDs = _context.Votacoes
                .Where(v => v.DataVotacao.Date == dataVotacao.Date)
                .Select(v => v.ProfissionalID)
                .ToList();
 
            List<Profissional> profissionaisQueNaoVotaram = todosProfissionais
                .Where(p => !profissionaisQueVotaramIDs.Contains(p.ProfissionalID))
                .ToList();

            return profissionaisQueNaoVotaram;
        }

        public int GetResults(DateTime dataVotacao)
        {
            int semanaAtual = GetIso8601WeekOfYear(dataVotacao);

            var resultVotacao = _context.Votacoes.AsEnumerable()
                .Where(v => SameWeek(v.DataVotacao, dataVotacao))
                .GroupBy(v => v.RestauranteID)
                .Select(g => new { RestauranteID = g.Key, Contagem = g.Count() })
                .OrderByDescending(r => r.Contagem)
                .FirstOrDefault();

            if (resultVotacao != null)
            {
                return resultVotacao.RestauranteID;
            }

            return -1;
        }

        public bool IsProfissionalCanVote(int profissionalID, DateTime dataVotacao)
        {
            bool alreadyVoted = _context.Votacoes.Any(v => v.ProfissionalID == profissionalID && v.DataVotacao.Date == dataVotacao.Date);

            return !alreadyVoted;
        }

  
        public bool isVotacaoFinished(DateTime dataVotacao)
        {
            int semanaAtual = GetIso8601WeekOfYear(DateTime.Now);

            List<int> profissionais = _context.Profissionais.Select(p => p.ProfissionalID).ToList();

            return profissionais.All(profissionalID =>
                _context.Votacoes.AsEnumerable().Any(v => v.ProfissionalID == profissionalID && SameWeek(v.DataVotacao, dataVotacao)));
        }

        private static bool SameWeek(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && GetIso8601WeekOfYear(date1) == GetIso8601WeekOfYear(date2);
        }
        private static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

    }
}
