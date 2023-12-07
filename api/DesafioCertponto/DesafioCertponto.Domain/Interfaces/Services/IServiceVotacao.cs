using DesafioCertponto.Application.DTO.DTO.Profissional;
using DesafioCertponto.Application.DTO.DTO.Restaurante;
using DesafioCertponto.Application.DTO.DTO.Votacao;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Model;

namespace DesafioCertponto.Domain.Interfaces.Services
{
    public interface IServiceVotacao : IBaseService<Votacao>
    {
        ApiResponse<VotacaoDTO> Add(VotacaoDTO votacaoDTO);
        ApiResponse<RestauranteDTO> GetResultadoVotacao();
        ApiResponse<IEnumerable<ProfissionalDTO>> GetProfissionaisDidntVote();
    }
}
