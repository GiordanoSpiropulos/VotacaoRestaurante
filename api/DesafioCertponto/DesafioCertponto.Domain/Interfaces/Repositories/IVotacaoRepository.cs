
using DesafioCertponto.Domain.Entities;

namespace DesafioCertponto.Domain.Interfaces.Repositories
{
    public interface IVotacaoRepository : IBaseRepository<Votacao>
    {
        IEnumerable<Profissional> ProfissionalThatDidntVote(DateTime dataVotacao);
        bool IsProfissionalCanVote(int profissionalID, DateTime dataVotacao);
        bool isVotacaoFinished(DateTime dataVotacao);
        int GetResults(DateTime dataVotacao);
    }
}
