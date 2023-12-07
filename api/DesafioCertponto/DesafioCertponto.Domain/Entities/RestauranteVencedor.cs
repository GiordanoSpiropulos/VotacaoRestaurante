namespace DesafioCertponto.Domain.Entities
{
    public class RestauranteVencedor
    {
        public int Id { get; set; }
        public int RestauranteID { get; set; }
        public DateTime DataVotacao { get; set; }
        public virtual Restaurante Restaurante { get; set; }
    }
}
