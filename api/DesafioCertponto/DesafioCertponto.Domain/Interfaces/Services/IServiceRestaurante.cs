using DesafioCertponto.Application.DTO.DTO.Restaurante;
using DesafioCertponto.Domain.Entities;
using DesafioCertponto.Domain.Model;

namespace DesafioCertponto.Domain.Interfaces.Services
{
    public interface IServiceRestaurante : IBaseService<Restaurante>
    {
        ApiResponse<RestauranteDTO> Add(RestauranteDTO restauranteDTO);

        ApiResponse<RestauranteDTO> Update(RestauranteDTO restauranteDTO);
    }
}
