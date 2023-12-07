
namespace DesafioCertponto.Application.DTO.DTO.Votacao
{
    public class VotacaoDTO
    {
        int VotacaoID { get; set; }
        public int ProfissionalID { get; set; }
        public int RestauranteID { get; set; }
        public DateTime? DataVotacao { get; set; }
    }
}
