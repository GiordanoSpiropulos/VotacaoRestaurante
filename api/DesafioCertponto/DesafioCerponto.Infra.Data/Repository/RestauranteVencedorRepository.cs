using System.Globalization;
using DesafioCerponto.Infra.Data.Context;
using DesafioCerponto.Infra.Data.Repository;
using DesafioCertponto.Application.DTO.DTO.Votacao;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Interfaces.Repositories;

namespace DesafioCertponto.Infra.Data.Repository
{
    public class RestauranteVencedorRepository : BaseRepository<RestauranteVencedor>, IRestauranteVencedorRepository
    {
        private readonly MySqlContext _context;
        public RestauranteVencedorRepository(MySqlContext Context)
            : base(Context)
        {
            _context = Context;
        }


        public  RestauranteVencedor GetRestauranteWinnerOfWeek(DateTime dataVotacao)
        {
            return _context.RestaurantesVencedor.Where(rv => rv.DataVotacao.Date == dataVotacao.Date).FirstOrDefault();
      
        }
        public int AddRestauranteWinnerOfWeek(DateTime dataVotacao, int restauranteVencedorID)
        {


            if (restauranteVencedorID != -1)
            {

                var restauranteVencedor = new RestauranteVencedor
                {
                    RestauranteID = restauranteVencedorID,
                    DataVotacao = dataVotacao
                };

                _context.RestaurantesVencedor.Add(restauranteVencedor);
                _context.SaveChanges();

                return restauranteVencedor.RestauranteID;
            }
            return -1;
        }

        public bool isRestauranteWinnerOfWeek(int restauranteID, DateTime dataVotacao)
        {
            return _context.RestaurantesVencedor.AsEnumerable()
               .Any(rv => rv.RestauranteID == restauranteID && SameWeek(rv.DataVotacao, dataVotacao));
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
