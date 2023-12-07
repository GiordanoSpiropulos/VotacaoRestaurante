namespace DesafioCertponto.Domain.Entities
{
    public class Votacao
    {
        public int VotacaoID { get; set; }

        public DateTime DataVotacao { get; set; }

        public virtual int ProfissionalID { get; set; }

        public virtual Profissional Profissional { get; set; }

        public virtual int RestauranteID { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}
