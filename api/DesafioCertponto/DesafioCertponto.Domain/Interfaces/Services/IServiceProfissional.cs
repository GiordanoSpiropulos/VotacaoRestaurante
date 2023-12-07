using DesafioCertponto.Application.DTO.DTO.Profissional;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Model;

namespace DesafioCertponto.Domain.Interfaces.Services
{
    public interface IServiceProfissional : IBaseService<Profissional>
    {
        ApiResponse<ProfissionalDTO> Add(ProfissionalDTO profissionalDTO);

        ApiResponse<ProfissionalDTO> Update(ProfissionalUpdateDTO profissionalUpdateDTO);
    }
}
