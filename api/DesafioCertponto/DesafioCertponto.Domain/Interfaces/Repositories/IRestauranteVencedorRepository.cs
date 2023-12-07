using DesafioCertponto.Domain.Entities;

namespace DesafioCertponto.Domain.Interfaces.Repositories
{
    public interface IRestauranteVencedorRepository : IBaseRepository<RestauranteVencedor>
    {
        RestauranteVencedor GetRestauranteWinnerOfWeek(DateTime dataVotacao);
        bool isRestauranteWinnerOfWeek(int restauranteID, DateTime dataVotacao);
        int AddRestauranteWinnerOfWeek(DateTime dataVotacao, int restauranteVencedorID);
    }
}
